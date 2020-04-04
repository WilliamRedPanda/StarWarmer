using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rest_OnPostAttack_EnemyBehaviour : BaseEnemyBehaviour
{
    protected override void OnPostAttack()
    {
        base.OnPostAttack();
        enemy.ChangeStateLogicSM("Rest");
    }
}
