using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerControllerInput : MonoBehaviour , IShooter
{
    [SerializeField] PlayerInputInstance instance;
    [SerializeField] SlowMotionController slowMotionController;
    [SerializeField] InputContainer inputsData;
    [SerializeField] CurrentControllerManager controllerManager;
    public PlayerData playerData;
    [SerializeField] Transform _shootPosition;
    [SerializeField] SpriteRenderer spriteCharacter;
    [SerializeField] Transform pointer;
    [SerializeField] Animator animator;
    [Space]
    [SerializeField] public Pause pause;
    [SerializeField] public ComboFacility comboFacility;
    [Space]
    [SerializeField] UnityEvent OnShootSkill;
    [SerializeField] UnityEvent OnShootRepulse;
    [SerializeField] UnityEvent OnInputPressedUE;
    [SerializeField] ParticleSystem onSequenceVfx;
    [Space]
    [Header("Audio")]
    [SerializeField] AudioClip dodgeClip;
    [SerializeField] AudioClip playerAtkClip;
    [SerializeField] AudioClip collideWallClip;
    [Space]
    public CinemachineBrain mainCamera;
    [Space]
    [SerializeField] Animator dxf;
    [SerializeField] Animator dxb, sxf, sxb;
    [SerializeField] SpriteRenderer dxfR, dxbR, sxfR, sxbR;
    //[SerializeField] Transform upLimit, downLimit, leftLimit, rightLimit;

    Rigidbody rb;
    Collider[] collider;

    public Vector3 shootPosition { get { return _shootPosition.position; } }
    public Vector3 aimDirection { get; private set; }

    public System.Action OnDestroy { get; set; }
    public System.Action<InputData> OnInputPressed { get; set; }
    public System.Action OnInputReset { get; set; }
    public System.Action OnEndSetupSequence { get; set; }

    public List<SetSequences> sequences { get; private set; }
    public List<SetSequences> currentSequencesSet { get; private set; }
    public List<SetSequences> sequencesToRemove;
    SetSequences executedSequence;
    public List<InputData> currentInputSequence { get; private set; }

    public InputData currentInput { get; private set; }

    bool _usingJoypad;
    bool usingJoypad 
    {
        get { return _usingJoypad; }
        set 
        {
            _usingJoypad = value;
            //if (_usingJoypad == false)
            //    controllerManager.ChangeController(inputDevice.keyboard);
            //else
            //    controllerManager.ChangeController(inputDevice.xBox);
        }
    }

    bool sequenceStarted = false;
    int consecutiveButtonPressed = -1;
    bool buttonJustPressed = false;
    float sequenceRemainTime;
    Animator[] animators;

    #region Mono
    private void Awake()
    {
        rb = GetComponentInChildren<Rigidbody>();
        collider = GetComponentsInChildren<Collider>();

        controllerManager.OnChangeController += CheckUsingJoypad;

        instance.SetInstance(this);
        playerData.OnChangeSequences += ChangeSequences;
        OnInputPressed += ctx => OnInputPressedUE?.Invoke();

        SetupSequences();

        animators = new Animator[] { dxb, dxf, sxb, sxf };

        SetRendererActive(AnimDirection.sxf);
    }

    void CheckUsingJoypad(inputDevice _inputDevice)
    {
        switch (_inputDevice)
        {
            case inputDevice.keyboard:
                usingJoypad = false;
                break;
            case inputDevice.playStation:
                usingJoypad = true;
                break;
            case inputDevice.xBox:
                usingJoypad = true;
                break;
            default:
                break;
        }
    }

    private void Start()
    {
        foreach (var sequence in sequences)
        {
            foreach (var command in sequence.commands)
            {
                BulletPoolManager.instance.TakeBullet(command.data.skillPrefab);
            }
        }
        if (Mouse.current != null)
            oldMousePosition = Mouse.current.position.ReadValue();
    }

    private void OnDisable()
    {
        OnDestroy?.Invoke();
        UnsubscribeSequences();
        playerData.OnChangeSequences -= ChangeSequences;
    }

    private void FixedUpdate()
    {
        if (canMove || playerData.canMove)
        {
            playerData.myRigidbody.MovePosition(transform.position + transformVelocity);
            //transform.Translate(transformVelocity, Space.World);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            SoundManager.instance.Play(collideWallClip);
        }
    }

    void SetupSequences()
    {
        sequences = new List<SetSequences>();
        currentSequencesSet = new List<SetSequences>();
        currentInputSequence = new List<InputData>();
        sequencesToRemove = new List<SetSequences>();
        foreach (var sequenceData in playerData.sequences)
        {
            SetSequences sequence = new SetSequences(sequenceData, this);
            sequence.onStartSequence += StartSequence;
            sequence.onCompletedSection += OnCorrectSequence;
            sequence.onExecute += Attack;
            foreach (var section in sequence.commands)
            {
                section.onCorrectInput += OnCorrectInput;
            }
            sequences.Add(sequence);
        }
        OnEndSetupSequence?.Invoke();
    }

    void UnsubscribeSequences()
    {
        foreach (var sequence in sequences)
        {
            sequence.ResetSequence();
            sequence.onStartSequence -= StartSequence;
            sequence.onCompletedSection -= OnCorrectSequence;
            sequence.onExecute -= Attack;
            foreach (var section in sequence.commands)
            {
                section.onCorrectInput -= OnCorrectInput;
            }
        }
        controllerManager.OnChangeController -= CheckUsingJoypad;
    }

    #endregion

    #region API
    public void HandlePlayer()
    {
        HandleSequence();
        Aim();
        HandleFire();
        slowMotionController.HandleSlowMo();
        if (playerData.canMove)
        {
            HandleDodge();
            Movement();
        }
    }

    public void ChangeSequences()
    {
        UnsubscribeSequences();
        SetupSequences();
    }
    
    public void ChangeSequences(int index, SetSequencesData setData)
    {
        UnsubscribeSequences();
        playerData.sequences[index] = setData;
        SetupSequences();
    }
    
    public void ChangeSequences(SetSequencesData[] _sequences)
    {
        UnsubscribeSequences();
        playerData.sequences = _sequences;
        SetupSequences();
    }

    public void SetRendererActive(AnimDirection _anim)
    {
        dxfR.enabled = false; dxbR.enabled = false; sxbR.enabled = false; sxfR.enabled = false;
        switch (_anim)
        {
            case AnimDirection.dxf:
                dxfR.enabled = true;
                break;
            case AnimDirection.dxb:
                dxbR.enabled = true;
                break;
            case AnimDirection.sxf:
                sxfR.enabled = true;
                break;
            case AnimDirection.sxb:
                sxbR.enabled = true;
                break;
            default:
                break;
        }
    }

    public void SetAnim(string _string)
    {
        foreach (var anim in animators)
        {
            anim.SetTrigger(_string);
        }
    }

    public void SetAnim(string _string, bool _bool)
    {
        foreach (var anim in animators)
        {
            anim.SetBool(_string, _bool);
        }
    }
    #endregion

    #region OtherInputHandler
    bool canDash = true;

    IEnumerator dodgeCorutine;
    private void HandleDodge()
    {
        if (Keyboard.current != null)
        {
            if (Keyboard.current[playerData.dodgeKey].wasPressedThisFrame)
            {
                StartDodge();
                return;
            }
        }

        if (Gamepad.current != null)
        {
            if (Gamepad.current.leftTrigger.wasPressedThisFrame)
            {
                StartDodge();
                return;
            }
        }
    }

    void StartDodge()
    {
        if (dodgeCorutine != null)
            StopCoroutine(dodgeCorutine);
        dodgeCorutine = Dodge();
        StartCoroutine(dodgeCorutine);
    }

    bool collideDodge = false;
    float dodgeTimer = 0;
    IEnumerator Dodge()
    {
        ResetVelocity();
        collideDodge = false;
        canDash = false;
        canMove = false;
        playerData.myRigidbody.useGravity = false;
        SetTrigger(true);
        
        playerData.TempInvulnerability(playerData.dodgeDuration);
        Vector3 dodgeVelocity;
        if (usingJoypad)
            dodgeVelocity = stickAxis.normalized * playerData.dodgeSpeed * Time.fixedDeltaTime;
        else
            dodgeVelocity = keyAxis.normalized * playerData.dodgeSpeed * Time.fixedDeltaTime;

        SoundManager.instance.Play(dodgeClip);

        RaycastHit hit;
        while (dodgeTimer < playerData.dodgeDuration)
        {
            dodgeTimer += Time.fixedDeltaTime;
            if (collideDodge == false)
            {
                if (Physics.Raycast(transform.position, dodgeVelocity, out hit, dodgeVelocity.magnitude))
                {
                    if (hit.transform.gameObject.tag == "Wall")
                    {
                        //transform.Translate((hit.point - transform.position) * 0.1f);
                        SoundManager.instance.Play(collideWallClip);
                        SetTrigger(true);
                        ResetVelocity();
                        collideDodge = true;
                        yield return new WaitForFixedUpdate();
                        break;
                    }
                    else
                        transform.Translate(dodgeVelocity, Space.World);
                }
                else
                    transform.Translate(dodgeVelocity, Space.World);
            }
            yield return new WaitForFixedUpdate();
        }
        dodgeTimer = 0;

        playerData.myRigidbody.useGravity = true;
        SetTrigger(false);
        canMove = true;

        yield return new WaitForSeconds(playerData.dodgeCooldown - playerData.dodgeDuration);
        canDash = true;
        collideDodge = false;
        yield return null;
    }

    bool canMove = true;
    bool isMove = false;

    Vector3 stickAxis;
    Vector3 keyAxis;
    float h;
    float v;
    Vector3 stickDirection;
    Vector3 direction;
    Vector3 transformVelocity;
    AnimDirection dir;

    public void ResetVelocity()
    {
        transformVelocity = Vector3.zero;
    }

    void Movement()
    {
        if (Gamepad.current != null)
        {
            stickAxis = new Vector3(Gamepad.current.leftStick.x.ReadValue(), 0, Gamepad.current.leftStick.y.ReadValue());
        }

        if (Keyboard.current != null)
        {
            float h = (Keyboard.current.aKey.ReadValue() * -1) + Keyboard.current.dKey.ReadValue();
            float v = (Keyboard.current.sKey.ReadValue() * -1) + Keyboard.current.wKey.ReadValue();
            keyAxis = new Vector3(h, 0, v);
        }

        if (controllerManager.currentController == inputDevice.keyboard)
            direction = keyAxis.normalized * playerData.speed;
        else
            direction = stickAxis.normalized * playerData.speed;

        transformVelocity += (direction - transformVelocity * playerData.friction) * Time.fixedDeltaTime;
        if (transformVelocity.magnitude < 0.01f && playerData.knockbackState == false)
            rb.velocity = Vector3.zero;

        //if (canMove)
        //{
        //    rb.MovePosition(transform.position + transformVelocity);
        //    //transform.Translate(transformVelocity, Space.World);
        //}
        if (playerData.canMove == false)
            transformVelocity = Vector3.zero;
        
        if (animator != null)
        {
            if (transformVelocity == Vector3.zero)
            {
                if (isMove == true)
                {
                    isMove = false;
                    animator.SetTrigger("Idle");
                    SetAnim("Move", isMove);
                }
            }
            else
            {
                if (isMove == false)
                {
                    isMove = true;
                    SetAnim("Move", isMove);
                }

                if (transformVelocity.z > 0f)
                {
                    if (transformVelocity.x < 0f)
                    {
                        if (dir != AnimDirection.sxb)
                        {
                            animator.SetTrigger("SXB");
                            dir = AnimDirection.sxb;
                        }
                    }
                    else if (transformVelocity.x >= 0f)
                    {
                        if (dir != AnimDirection.dxb)
                        {
                            animator.SetTrigger("DXB");
                            dir = AnimDirection.dxb;
                        }
                    }
                }
                else if (transformVelocity.z <= 0f)
                {
                    if (transformVelocity.x < 0f)
                    {
                        if (dir != AnimDirection.sxf)
                        {
                            animator.SetTrigger("SXF");
                            dir = AnimDirection.sxf;
                        }
                    }
                    else if (transformVelocity.x >= 0f)
                    {
                        if (dir != AnimDirection.dxf)
                        {
                            animator.SetTrigger("DXF");
                            dir = AnimDirection.dxf;
                        }
                    }
                }
            }
        }

        if ((stickAxis.x < -0.1f || stickAxis.x > 0.1f) || (stickAxis.z < -0.1f || stickAxis.z > 0.1f))
        {
            stickDirection = Quaternion.LookRotation(stickAxis) * Vector3.forward;
        }

        if (spriteCharacter)
        {
            if (stickAxis.x < 0 && spriteCharacter.flipX == false)
            {
                spriteCharacter.flipX = true;
            }
            else if (stickAxis.x > 0 && spriteCharacter.flipX == true)
            {
                spriteCharacter.flipX = false;
            }
        }
    }

    Vector3 pointerDirection;
    Vector2 mouseVelocity = Vector2.zero;
    Vector2 oldMousePosition;
    void Aim()
    {
        if (Mouse.current != null)
        {
            mouseVelocity = Mouse.current.position.ReadValue() - oldMousePosition;
            oldMousePosition = Mouse.current.position.ReadValue();

            if ((mouseVelocity.x < -0.1f || mouseVelocity.x > 0.1f || mouseVelocity.y < -0.1f || mouseVelocity.y > 0.1f ||
                keyAxis.x < -0.1f || keyAxis.x > 0.1f || keyAxis.y < -0.1f || keyAxis.y > 0.1f || Mouse.current.IsPressed()) && usingJoypad == true)
            {
                //usingJoypad = false;
            }
        }

        if (playerData.autoAim == false)
        {
            if ((stickAxis.x < -0.1f || stickAxis.x > 0.1f) || (stickAxis.z < -0.1f || stickAxis.z > 0.1f))
            {
                aimDirection = stickDirection;
                //usingJoypad = true;
            }


            if (controllerManager.currentController == inputDevice.keyboard)
            {
                Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
                RaycastHit raycastHit;
                if (Physics.Raycast(ray, out raycastHit, Mathf.Infinity))
                {
                    Vector3 raycastPoint = raycastHit.point;
                    Vector3 pointOnPlayerHight = new Vector3(raycastPoint.x, transform.position.y, raycastPoint.z);
                    Vector3 _direction = pointOnPlayerHight - transform.position;
                    aimDirection = _direction.normalized;
                }
            }
        }
        else
        {
            Vector3 shooterPosition = transform.position;
            Collider[] colliders = Physics.OverlapSphere(shooterPosition, playerData.autoAimRange);

            Transform characterToAim = null;
            Vector3 target = Vector3.zero;

            for (int i = 0; i < colliders.Length; i++)
            {
                CharacterBase enemyTemp = colliders[i].GetComponentInParent<CharacterBase>();

                if (enemyTemp == null) continue;

                if (enemyTemp.gameObject.GetComponent<PlayerData>()) continue;

                if (characterToAim == null)
                {
                    characterToAim = enemyTemp.transform;
                    target = characterToAim.position;
                    continue;
                }

                if (Vector3.Distance(enemyTemp.transform.position, shooterPosition) < Vector3.Distance(target, shooterPosition))
                {
                    characterToAim = enemyTemp.transform;
                    target = characterToAim.position;
                    continue;
                }
            }

            if (characterToAim == null)
            {
                target = shooterPosition + Vector3.up;
            }

            aimDirection = (target - shooterPosition).normalized;
        }

        if (pointer)
        {
            pointerDirection = new Vector3(aimDirection.x, pointer.transform.position.y, aimDirection.z);
            pointer.rotation = Quaternion.LookRotation(pointerDirection) * Quaternion.Euler(90, -90, 0);
        }
    }

    bool shooted;
    bool onCooldown;

    void HandleFire()
    {
        if (playerData.bullet != null)
        {
            if (BulletPoolManager.instance != null)
            {
                if (Gamepad.current != null)
                {
                    if (Gamepad.current.rightTrigger.wasPressedThisFrame && shooted == false && onCooldown == false)
                    {
                        shooted = true;
                        BulletPoolManager.instance.Shoot(playerData.bullet, _shootPosition.position, aimDirection, this, null);
                        OnShootRepulse?.Invoke();
                        Attack();
                    }
                    else if (Gamepad.current.rightTrigger.wasReleasedThisFrame && shooted == true)
                    {
                        shooted = false;
                    }
                }

                if (Mouse.current != null)
                {
                    if (Mouse.current.leftButton.wasPressedThisFrame && onCooldown == false)
                    {
                        BulletPoolManager.instance.Shoot(playerData.bullet, _shootPosition.position, aimDirection, this, null);
                        OnShootRepulse?.Invoke();
                        Attack();
                    }
                }
            }
        }
    }

    IEnumerator Cooldown()
    {
        onCooldown = true;
        float _cool = playerData.cooldown;
        yield return new WaitForSeconds(_cool);
        onCooldown = false;
    }

    void Attack(SetSequences set = null)
    {
        StartCoroutine(Cooldown());
        SoundManager.instance.Play(playerAtkClip);
        SetAnim("Attack");
    }
    #endregion

    #region Sequence
    void HandleSequence()
    {
        buttonJustPressed = false;

        if (sequenceStarted == false)
        {
            HandleInput();
            foreach (var sequence in sequences)
            {
                //if (sequence.canExecute)
                    sequence.HandleSetSequences();
            }
        }
        else
        {
            HandleInput();
            foreach (var sequence in sequencesToRemove)
            {
                currentSequencesSet.Remove(sequence);
            }
            sequencesToRemove.Clear();

            foreach (var sequence in currentSequencesSet)
            {
                sequence.HandleSetSequences();
            }
        }

        if (sequenceStarted == true && (Time.time > sequenceRemainTime))
        {
             ExecuteSequence();
        }
    }

    void HandleInput()
    {
        if (Keyboard.current != null)
        {
            if (Keyboard.current.anyKey.wasPressedThisFrame)
            {
                CheckAllComboInput();
            }
        }

        if (Gamepad.current != null)
        {
            if (Gamepad.current.IsPressed())
            {
                CheckAllComboInput();
            }
        }
    }

    bool CheckAllComboInput()
    {
        foreach (var input in inputsData.inputs)
        {
            if (input.CheckInputPressed())
            {
                if (sequenceStarted == false)
                {
                    sequenceStarted = true;
                }
                currentInputSequence.Add(input);
                OnInputPressed?.Invoke(input);
                if (onSequenceVfx.isStopped)
                    onSequenceVfx.Play();
                buttonJustPressed = true;
                sequenceRemainTime = Time.time + playerData.timeForSequence;
                return true;
            }
        }
        return false;
    }

    void StartSequence(SetSequences s)
    {
        if (sequenceStarted == false)
        {
            sequenceStarted = true;
        }
        currentSequencesSet.Add(s);
    }

    void OnCorrectSequence(SetSequences s)
    {
        executedSequence = s;
    }

    void OnCorrectInput(InputData input)
    {
        if (!buttonJustPressed)
        {
            currentInputSequence.Add(input);
            consecutiveButtonPressed++;
            buttonJustPressed = true;
        }
        sequenceRemainTime = Time.time + playerData.timeForSequence;
    }

    void ResetSequences()
    {
        consecutiveButtonPressed = -1;
        foreach (var sequence in currentSequencesSet)
        {
            sequence.ResetSequence();
        }
        currentSequencesSet.Clear();
        currentInputSequence.Clear();
        OnInputReset?.Invoke();
        sequenceStarted = false;
        onSequenceVfx.Stop();
        onSequenceVfx.Clear();
    }

    void ExecuteSequence()
    {
        if (executedSequence != null)
        {
            if (currentSequencesSet.Contains(executedSequence))
            {
                if (executedSequence.canExecute)
                {
                    OnShootSkill?.Invoke();
                    executedSequence.Execute();
                    StopCoroutine(executedSequence.cooldownCorutine);
                    executedSequence.RestartCooldownCorutine();
                    StartCoroutine(executedSequence.cooldownCorutine);
                    executedSequence = null;
                }
                else
                {
                    SoundManager.instance.Play("ComboFailed");
                }
            }
        }
        else
        {
            SoundManager.instance.Play("ComboFailed");
        }
        ResetSequences();
    }
    #endregion

    void SetTrigger(bool _trigger)
    {
        int l = collider.Length;
        for (int i = 0; i < collider.Length; i++)
        {
            collider[i].isTrigger = _trigger;
        }
    }

}

public enum AnimDirection
{
    dxf, dxb, sxf, sxb,
}