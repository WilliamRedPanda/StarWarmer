using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_ChargeTarget_EnemyBehaviour : BaseEnemyBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float rangeAttack;
    [SerializeField] int damage;

    Vector3 endPosition;
    Vector3 direction;
    float timer;

    protected override void OnStartPhaseAttack()
    {
        base.OnStartPhaseAttack();
        endPosition = enemy.target.transform.position;
        direction = (endPosition - enemy.transform.position).normalized;
        timer = 0;
    }

    Collider[] endPosColliders;
    Collider[] attackColliders;
    protected override void Attack()
    {
        base.Attack();
        endPosColliders = Physics.OverlapSphere(endPosition, 0.1f);
        attackColliders = Physics.OverlapSphere(enemy.transform.position, rangeAttack);
        for (int i = 0; i < endPosColliders.Length; i++)
        {
            GenericEnemy tempEnemy = endPosColliders[i].GetComponentInParent<GenericEnemy>();
            if (enemy)
            {
                if (tempEnemy == enemy)
                    enemy.ChangeStateLogicSM("Rest");
            }
        }

        for (int i = 0; i < attackColliders.Length; i++)
        {
            PlayerData playerData = attackColliders[i].GetComponentInParent<PlayerData>();
            if (playerData)
            {
                playerData.TakeDamage(damage, null, enemy);
                enemy.ChangeStateLogicSM("Rest");
            }
        }
        enemy.moving = true;
        enemy.transformVelocity = (endPosition - enemy.transform.position).normalized * speed * Time.fixedDeltaTime;
    }

    protected override void OnCollide(Collision _collision)
    {
        base.OnCollide(_collision);
        if (_collision.gameObject.tag == "Wall")
        {
            enemy.ChangeStateLogicSM("Rest");
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, rangeAttack);
    }
}