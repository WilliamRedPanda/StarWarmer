using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GenericEnemy))]
public abstract class BaseEnemyBehaviour : MonoBehaviour
{
    protected GenericEnemy enemy;

    protected virtual void OnEnable()
    {
        enemy = GetComponentInParent<GenericEnemy>();

        enemy.OnStartPatrol      += OnStartPatrol;
        enemy.OnPatrol           += PatrolTick;
        enemy.OnStartAggro       += OnStartAggro;
        enemy.OnAggro            += AggroTick;
        enemy.OnStartPhaseAttack += OnStartPhaseAttack;
        enemy.OnPreAttack        += OnPreAttack;
        enemy.OnAttack           += Attack;
        enemy.OnPostAttack       += OnPostAttack;
        enemy.OnEndPhaseAttack   += OnEndPhaseAttack;
        enemy.OnStartRest        += OnStartRest;
        enemy.OnRest             += RestTick;
        enemy.OnTakeDamage       += OnDamage;
        enemy.OnPlayerCollide    += OnCollidePlayer;
        enemy.OnCollide          += OnCollide;
    }

    protected virtual void OnDamage(int _damage, CommandSequence _command, IShooter _shooter) { }

    protected virtual void OnStartPatrol() { }

    protected virtual void PatrolTick() { }

    public virtual void OnStartAggro() { }

    protected virtual void AggroTick() { }

    protected virtual void OnStartPhaseAttack() { }

    protected virtual void OnPreAttack() { }

    protected virtual void Attack() { }

    protected virtual void OnPostAttack() { }

    protected virtual void OnEndPhaseAttack() { }

    protected virtual void OnStartRest() { }

    protected virtual void RestTick() { }

    protected virtual void OnCollidePlayer(PlayerData _playerData) { }

    protected virtual void OnCollide(Collision _collision) { }

    private void OnDisable()
    {
        enemy.OnStartPatrol      -= OnStartPatrol;
        enemy.OnPatrol           -= PatrolTick;
        enemy.OnStartAggro       -= OnStartAggro;
        enemy.OnAggro            -= AggroTick;
        enemy.OnStartPhaseAttack -= OnStartPhaseAttack;
        enemy.OnPreAttack        -= OnPreAttack;
        enemy.OnAttack           -= Attack;
        enemy.OnPostAttack       -= OnPostAttack;
        enemy.OnEndPhaseAttack   -= OnEndPhaseAttack;
        enemy.OnStartRest        -= OnStartRest;
        enemy.OnRest             -= RestTick;
        enemy.OnTakeDamage       -= OnDamage;
        enemy.OnPlayerCollide    -= OnCollidePlayer;
        enemy.OnCollide          -= OnCollide;
    }
}