using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GenericEvent_States_EnemyBehaviour : BaseEnemyBehaviour
{
    [SerializeField] UnityEvent onStartPatrol;
    [SerializeField] UnityEvent onStartAggro;
    [SerializeField] UnityEvent onStartRest;

    protected override void OnStartPatrol()
    {
        base.OnStartPatrol();
        onStartPatrol?.Invoke();
    }

    public override void OnStartAggro()
    {
        base.OnStartAggro();
        onStartAggro?.Invoke();
    }

    protected override void OnStartRest()
    {
        base.OnStartRest();
        onStartRest?.Invoke();
    }
}
