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

        enemy.OnStartPatrol += OnStartPatrol;
        enemy.OnPatrol      += PatrolTick;
        enemy.OnStartAggro  += OnStartAggro;
        enemy.OnAggro       += AggroTick;
        enemy.OnPreAttack   += OnPreAttack;
        enemy.OnAttack      += Attack;
        enemy.OnPostAttack  += OnPostAttack;
        enemy.OnStartRest   += OnStartRest;
        enemy.OnRest        += RestTick;
    }


    protected virtual void OnStartPatrol()
    {

    }

    protected virtual void PatrolTick()
    {

    }

    public virtual void OnStartAggro()
    {
        
    }

    protected virtual void AggroTick()
    {

    }

    protected virtual void OnPreAttack()
    {

    }

    protected virtual void Attack()
    {

    }

    protected virtual void OnPostAttack()
    {

    }

    protected virtual void OnStartRest()
    {

    }

    protected virtual void RestTick()
    {

    }

    private void OnDisable()
    {
        enemy.OnStartPatrol -= OnStartPatrol;
        enemy.OnPatrol      -= PatrolTick;
        enemy.OnStartAggro  -= OnStartAggro;
        enemy.OnAggro       -= AggroTick;
        enemy.OnPreAttack   -= OnPreAttack;
        enemy.OnAttack      -= Attack;
        enemy.OnPostAttack  -= OnPostAttack;
        enemy.OnStartRest   -= OnStartRest;
        enemy.OnRest        -= RestTick;
    }
}
