using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GenericEvent_Attack_EnemyBehaviour : BaseEnemyBehaviour
{
    [SerializeField] UnityEvent OnStartAttack;
    [SerializeField] UnityEvent OnEndAttack;

    protected override void OnStartPhaseAttack()
    {
        base.OnStartPhaseAttack();
        OnStartAttack.Invoke();
    }

    protected override void OnEndPhaseAttack()
    {
        base.OnEndPhaseAttack();
        OnEndAttack.Invoke();
    }
}
