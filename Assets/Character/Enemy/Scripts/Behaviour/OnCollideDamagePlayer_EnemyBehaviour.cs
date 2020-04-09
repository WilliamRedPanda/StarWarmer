using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollideDamagePlayer_EnemyBehaviour : BaseEnemyBehaviour
{
    [SerializeField] int damage;
    protected override void OnCollidePlayer(PlayerData _playerData)
    {
        base.OnCollidePlayer(_playerData);
        _playerData.TakeDamage(damage, null, enemy);
    }
}