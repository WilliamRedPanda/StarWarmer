using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public abstract class CharacterBase : MonoBehaviour, IDamageable
{
    const float KNOCKBACK_RATE = .5f;

    #region Serialized
    [Header("Health")]
    [SerializeField] int _currentHealth;
    [SerializeField] int _maxHealth;
    [SerializeField] protected float durationDamageFeedback = 0.5f;
    [SerializeField] UnityEvent onDamageUE;
    [SerializeField] UnityEvent onDeathUE;
    #endregion

    #region Interface_Damageable
    public int currentHealth { 
        get => _currentHealth; 
        set 
        {
            if (value >= maxHealth) _currentHealth = maxHealth;
            else if (value < 0)     _currentHealth = 0;
            else                    _currentHealth = value;
            OnHealthChange?.Invoke(_currentHealth);
        } 
    }
    public int maxHealth { get => _maxHealth; set => _maxHealth = value; }
    public bool isDead { get; set; }
    public bool invulnerable { get; set; } 
    #endregion

    public Action<int> OnHealthChange { get; set; }
    public Action<int, CommandSequence, IShooter> OnTakeDamage { get; set; }
    public Action<IDamageable> OnDeath { get; set; }

    public Action OnStun;
    public Action OnStopStun;

    public Rigidbody myRigidbody { get; private set; }

    public bool knockbackState { get; protected set; }
    [HideInInspector] public bool canMove;

    public Renderer renderer { get; protected set; }
    public Material originalMaterial { get; protected set; }

    public virtual void TakeDamage(int _damage, CommandSequence _command, IShooter _shooter)
    {
        if (!invulnerable)
        {
            if (currentHealth <= 0)
                return;

            currentHealth -= _damage;
            onDamageUE?.Invoke();
            OnTakeDamage?.Invoke(_damage, _command, _shooter);

            if (_damage > 0)
            {
                if (damageFeedbackCorutine != null)
                    StopCoroutine(damageFeedbackCorutine);
                damageFeedbackCorutine = DamageFeedbackCorutine();
                StartCoroutine(damageFeedbackCorutine);
            }

            if (currentHealth <= 0)
            {
                OnDeath?.Invoke(this);
                onDeathUE?.Invoke();
            }
        }
    }

    public void Stop(float _timer)
    {
        if (stopCoroutine != null)
            StopCoroutine(stopCoroutine);
        stopCoroutine = StopCharacterCorutine(_timer);
        StartCoroutine(stopCoroutine);
    }
    IEnumerator stopCoroutine;
    IEnumerator StopCharacterCorutine(float _timer)
    {
        Vector3 currentPosition = transform.position;
        canMove = false;
        float t = _timer;
        while (_timer > 0f)
        {
            transform.position = currentPosition;
            _timer -= Time.deltaTime;
            yield return null;
        }
        canMove = true;
    }

    public void Heal(int _heal)
    {
        currentHealth += _heal;
    }

    public void Heal()
    {
        Heal(maxHealth);
    }

    IEnumerator damageFeedbackCorutine;
    protected virtual IEnumerator DamageFeedbackCorutine()
    {
        //renderer.material = damageMaterial;
        //yield return new WaitForSeconds(0.5f);
        //renderer.material = originalMaterial;
        yield return null;
    }

    public virtual void Stun(float _duration)
    {
        OnStun?.Invoke();
        Stop(_duration);
    }

    IEnumerator knockbackCorutine;
    public virtual void KnockBack(float _force, Vector3 _hitPoint, float _radius)
    {
        //if (!knockbackState)
        //{
        if (knockbackCorutine != null)
            StopCoroutine(knockbackCorutine);
        knockbackState = true;
        knockbackCorutine = KnockbackCorutine();
        //myRigidbody.AddExplosionForce(_force, _hitPoint, _radius, 0f, ForceMode.Impulse);
        myRigidbody.AddForce((transform.position - _hitPoint).normalized * _force, ForceMode.VelocityChange);
        StartCoroutine(knockbackCorutine);
        //}
    }

    IEnumerator KnockbackCorutine()
    {
        yield return new WaitForSeconds(KNOCKBACK_RATE);
        myRigidbody.velocity = Vector3.zero;
        knockbackState = false;
    }

    protected virtual void Awake()
    {
        myRigidbody = GetComponentInChildren<Rigidbody>();
        renderer = GetComponentInChildren<Renderer>();
        if (renderer)
            originalMaterial = renderer.material;
        invulnerable = false;
        canMove = true;
    }

    public void SetMaterial(Material newMaterial)
    {
        if (renderer)
            renderer.material = newMaterial;
    }

    IEnumerator invulnerabilityCorutine;
    public void TempInvulnerability(float _duration)
    {
        if (invulnerabilityCorutine != null)
            StopCoroutine(invulnerabilityCorutine);
        invulnerabilityCorutine = InvulnerabilityCorutine(_duration);
        StartCoroutine(invulnerabilityCorutine);
    }

    IEnumerator InvulnerabilityCorutine(float _duration)
    {
        invulnerable = true;
        yield return new WaitForSeconds(_duration);
        invulnerable = false;
    }
}