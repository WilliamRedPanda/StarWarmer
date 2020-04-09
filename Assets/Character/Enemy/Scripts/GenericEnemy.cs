using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericEnemy : CharacterBase , IShooter
{
    [Header("Enemy")]
    [SerializeField] int exp;
    public BulletBase bullet;
    public float restTimer;
    [SerializeField] Transform _shootPosition;
    [SerializeField] Animator logicSM;
    [SerializeField] GameObject stunObject;
    [Space]
    [SerializeField] Animator dxfSM;
    [SerializeField] Animator dxbSM;
    [SerializeField] Animator sxfSM;
    [SerializeField] Animator sxbSM;
    [SerializeField] SpriteRenderer dxfR, dxbR, sxfR, sxbR;

    Animator[] animators;
    CommandSequence lastHitCommand;

    Transform targetTransform;
    float timer;

    [HideInInspector] public PlayerData target;

    public Vector3 shootPosition { get { return _shootPosition.position; } }
    public Vector3 aimDirection { get; set; }

    [HideInInspector] public bool moving;
    [HideInInspector] public Vector3 transformVelocity;

    public Action OnDestroy { get; set; }
    public Action OnStartPatrol;
    public Action OnPatrol;
    public Action OnStartAggro;
    public Action OnAggro;
    public Action OnStartPhaseAttack;
    public Action OnPreAttack;
    public Action OnAttack;
    public Action OnPostAttack;
    public Action OnStartRest;
    public Action OnRest;
    public Action<Collision> OnCollide;
    public Action<PlayerData> OnPlayerCollide;

    protected override void Awake()
    {
        base.Awake();
        OnTakeDamage += Damage;
        OnDeath += Death;
        stunObject.SetActive(false);
        animators = new Animator[] { dxbSM, sxbSM, dxfSM, sxfSM };
        SetRendererActive(AnimDirection.dxf);
        OnPreAttack += Attack;
    }

    private void FixedUpdate()
    {
        if (moving == true)
        {
            Move(transform.position + transformVelocity);
            transformVelocity = transform.position;
            moving = false;
        }
    }

    #region API
    IEnumerator stunTimerCorutine;
    public override void Stun(float _duration)
    {
        base.Stun(_duration);
        ChangeStateLogicSM("Stun");
        if (stunTimerCorutine == null)
            stunTimerCorutine = StunTimerCorutine(_duration);
        StopCoroutine(stunTimerCorutine);
        StartCoroutine(stunTimerCorutine);
    }
    IEnumerator StunTimerCorutine(float _timer)
    {
        stunObject.SetActive(true);
        yield return new WaitForSeconds(_timer);
        stunObject.SetActive(false);
        OnStopStun?.Invoke();
        ChangeStateLogicSM("Aggro");
    }

    public void PatrolTick()
    {
        OnPatrol?.Invoke();
    }

    public void AggroTick()
    {
        OnAggro?.Invoke();
    }

    public void RestTick()
    {
        OnRest?.Invoke();
    }

    AnimDirection oldDir;
    public void SetRendererActive(AnimDirection _anim)
    {
        if (oldDir != null)
            if (oldDir == _anim)
                return;

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
        oldDir = _anim;
    }

    public void ChangeStateLogicSM(string _state)
    {
        logicSM.SetTrigger(_state);
    }

    public void ChangeStateAnimationSM(string _state)
    {
        foreach (var anim in animators)
        {
            anim.SetTrigger(_state);
        }
    }
    
    public void ChangeStateAnimationSM(string _state, bool _bool)
    {
        foreach (var anim in animators)
        {
            anim.SetBool(_state, _bool);
        }
    }

    bool isMove = false;
    AnimDirection dir;
    Vector3 movementDirection; 
    public void Move(Vector3 _pos)
    {
        //if (transform.position == _pos)
        //{
        //    return;
        //    ChangeStateAnimationSM("Move", isMove);
        //}

        myRigidbody.MovePosition(_pos);

        movementDirection =  (_pos - transform.position).normalized;

        if (_pos == transform.position)
        {
            if (isMove == true)
            {
                isMove = false;
                ChangeStateAnimationSM("Move", isMove);
            }
        }
        else
        {
            if (isMove == false)
            {
                isMove = true;
                ChangeStateAnimationSM("Move", isMove);
            }

            if (movementDirection.z > 0.1f)
            {
                if (movementDirection.x < 0f)
                {
                    if (dir != AnimDirection.sxb)
                    {
                        dir = AnimDirection.sxb;
                    }
                }
                else if (movementDirection.x >= 0f)
                {
                    if (dir != AnimDirection.dxb)
                    {
                        dir = AnimDirection.dxb;
                    }
                }
            }
            else if (movementDirection.z <= 0.1f)
            {
                if (movementDirection.x < 0f)
                {
                    if (dir != AnimDirection.sxf)
                    {
                        dir = AnimDirection.sxf;
                    }
                }
                else if (movementDirection.x >= 0f)
                {
                    if (dir != AnimDirection.dxf)
                    {
                        dir = AnimDirection.dxf;
                    }
                }
            }
        }

        SetRendererActive(dir);
    }

    public void Attack()
    {
        ChangeStateAnimationSM("Attack");
    }
    #endregion

    void Death(IDamageable _damageable)
    {
        if (lastHitCommand != null)
            lastHitCommand.AddExp(exp);
        OnDeath -= Death;
        Destroy(gameObject);
    }

    void Damage(int _damage, CommandSequence _command, IShooter _shooter)
    {
        lastHitCommand = _command;
        if (lastHitCommand != null)
            lastHitCommand.AddExp(1);
        timer = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        PlayerData playerData = collision.gameObject.GetComponentInParent<PlayerData>();
        if (playerData)
        {
            OnPlayerCollide?.Invoke(playerData);
        }

        OnCollide?.Invoke(collision);
    }
}