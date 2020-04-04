using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aggro_AttackWhenYouCan_EnemyBehaviour : BaseEnemyBehaviour
{
    public override void OnStartAggro()
    {
        base.OnStartAggro();
        enemy.ChangeStateLogicSM("Attack");
    }
}