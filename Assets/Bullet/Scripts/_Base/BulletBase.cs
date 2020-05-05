using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBase : MonoBehaviour
{
    public int ID;
    [SerializeField] protected ParticleSystem vfx;
    [SerializeField] float _duration;
    //TODO: Da considerare temporaneo fino ulteriori informazioni
    [SerializeField] int damage;
    //
    [SerializeField] bool friendlyFire;

    [Header("Component")]
    [SerializeField] Rigidbody rb;

    public float duration { get { return _duration; } }

    public State state { get; set; }
    public bool created { get; set; }
    float returnTime;
    [HideInInspector] public IShooter shooter;
    [HideInInspector] public CommandSequence command;
    [HideInInspector] public Vector3 target;

    public Action OnPreShoot;
    public Action OnShoot;
    public Action<Collider> OnEnterCollider;
    public Action<IDamageable> OnDamage;
    public Action OnPostDamage;
    public Action OnReturn;
    public Action OnFixedUpdate;

    Vector3 transformVelocity;
    public bool reflect { get; private set; }

    public void SetMove(Vector3 v3, Space space)
    {
        if (space == Space.World)
        {
            transformVelocity += (v3 - transform.position);
        }
        else
        {
            transformVelocity += v3;
        }
    }

    public void Reflect()
    {
        reflect = !reflect;
    }

    void ApplyMovement()
    {
        if (reflect)
            transformVelocity *= -1;

        if (rb != null)
            rb.MovePosition(transformVelocity + transform.position);
        else
            transform.Translate(transformVelocity, Space.World);

        transformVelocity = Vector3.zero;
    }

    protected virtual void Tick()
    {
        if (Time.time > returnTime)
            Return();
    }

    #region API
    public virtual void Shoot(Vector3 shootPosition, Vector3 direction, IShooter _shooter, CommandSequence _command)
    {
        shooter = _shooter;
        transform.position = shootPosition;
        transform.rotation = Quaternion.LookRotation(direction);
        gameObject.SetActive(true);
        state = State.Shooted;
        command = _command;
        returnTime = Time.time + _duration;
        OnPreShoot?.Invoke();
        OnShoot?.Invoke();
        if (vfx != null)
            vfx.Play();
    }

    public virtual void Return()
    {
        reflect = false;
        if (vfx != null)
        {
            vfx.Stop();
            vfx.Clear();
        }
        OnReturn?.Invoke();
        BulletPoolManager.instance.ReturnBullet(this);
    }
    #endregion

    public virtual void OnDamageableCollide(IDamageable damageable)
    {
        OnDamage?.Invoke(damageable);
        damageable.TakeDamage(damage, command, shooter);
        OnPostDamage?.Invoke();
    }

    private void OnEnable()
    {
        if (!created)
            created = true;
    }

    //private void FixedUpdate()
    //{
    //    if (state == State.Shooted)
    //        ApplyMovement();
    //}

    private void Update()
    {
        if (state == State.Shooted)
        {
            Tick();
        }
    }

    private void FixedUpdate()
    {
        if (state == State.Shooted)
        {
            OnFixedUpdate?.Invoke();
            ApplyMovement();
        }
    }

    public enum State
    {
        Pooled,
        Shooted,
    }

    private void OnTriggerEnter(Collider other)
    {
        OnEnter(other);
    }

    private void OnTriggerExit(Collider other)
    {
        OnExit(other);
    }

    public void OnEnter(Collider other)
    {
        if (state == State.Shooted)
        {
            IDamageable damageable = other.GetComponentInParent<IDamageable>();
            if (damageable != null)
            {
                if (!friendlyFire && ((damageable is GenericEnemy && shooter is GenericEnemy) || (damageable is PlayerData && shooter is PlayerControllerInput)))
                {
                    // Nothing
                }
                else if (damageable.gameObject != shooter.gameObject && damageable.invulnerable == false)
                {
                    OnDamageableCollide(damageable);
                }
            }
            OnEnterCollider?.Invoke(other);
        }
    }

    public void OnExit(Collider other)
    {
        if (state == State.Shooted)
        {
            RoomSwitch roomSwitch = other.GetComponent<RoomSwitch>();
            if (roomSwitch != null)
            {
                Return();
            }
        }
    }
}