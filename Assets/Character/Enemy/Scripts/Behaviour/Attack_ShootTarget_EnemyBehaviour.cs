using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_ShootTarget_EnemyBehaviour : BaseEnemyBehaviour
{
    [SerializeField] float fireRate;

    float timer;

    protected override void OnPreAttack()
    {
        base.OnPreAttack();
        enemy.aimDirection = enemy.target.transform.position - transform.position;
    }

    protected override void Attack()
    {
        base.Attack();
        timer += Time.deltaTime;
        if (timer >= fireRate)
        {
            timer = 0f;
            BulletPoolManager.instance.Shoot(enemy.bullet, enemy.shootPosition, enemy.aimDirection, enemy, null);
        }
    }
}