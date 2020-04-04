using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericEnemy : CharacterBase , IShooter
{
    [SerializeField] int exp;
    public BulletBase bullet;
    [SerializeField] Transform _shootPosition;
    [SerializeField] Animator logicSM, animationSM;
    public float restTimer;
    [SerializeField] GameObject stunObject;

    CommandSequence lastHitCommand;

    Transform targetTransform;
    float timer;

    [HideInInspector] public PlayerData target;

    public Vector3 shootPosition { get { return _shootPosition.position; } }
    public Vector3 aimDirection { get; set; }

    public Action OnDestroy { get; set; }
    public Action OnStartPatrol;
    public Action OnPatrol;
    public Action OnStartAggro;
    public Action OnAggro;
    public Action OnPreAttack;
    public Action OnAttack;
    public Action OnPostAttack;
    public Action OnStartRest;
    public Action OnRest;

    protected override void Awake()
    {
        base.Awake();
        OnTakeDamage += Damage;
        OnDeath += Death;
        stunObject.SetActive(false);
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

    public void ChangeStateLogicSM(string _state)
    {
        logicSM.SetTrigger(_state);
    }

    public void ChangeStateAnimationSM(string _state)
    {
        animationSM.SetTrigger(_state);
    }

    public void Move(Vector3 _pos)
    {
        myRigidbody.MovePosition(_pos);
    }

    public void Attack()
    {
        timer = 0f;
        BulletPoolManager.instance.Shoot(bullet, shootPosition, aimDirection, this, null);
    }
    #endregion

    void Death(IDamageable _damageable)
    {
        if (lastHitCommand != null)
            lastHitCommand.AddExp(exp);
        OnDeath -= Death;
        Destroy(gameObject);
    }

    void Damage(int _damage, CommandSequence _command)
    {
        lastHitCommand = _command;
        if (lastHitCommand != null)
            lastHitCommand.AddExp(1);
        timer = 0;
    }
}