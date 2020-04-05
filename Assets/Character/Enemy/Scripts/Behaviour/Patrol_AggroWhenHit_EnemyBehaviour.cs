using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol_AggroWhenHit_EnemyBehaviour : BaseEnemyBehaviour
{
    protected override void OnDamage(int _damage, CommandSequence _command, IShooter _shooter)
    {
        base.OnDamage(_damage, _command, _shooter);
        if (_shooter is PlayerControllerInput)
        {
            PlayerControllerInput playerInput = (PlayerControllerInput)_shooter;
            enemy.target = playerInput.playerData;
            enemy.ChangeStateLogicSM("Aggro");
            this.enabled = false;
        }
    }
}