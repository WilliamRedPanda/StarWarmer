using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Attack_ChargeTarget_EnemyBehaviour : BaseEnemyBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float rangeAttack;
    [SerializeField] int damage;
    [SerializeField] float knockbackForce = 5f;
    [SerializeField] UnityEvent onHitPlayer;
    [SerializeField] UnityEvent onHitWall;
    [SerializeField] UnityEvent onNoHit;

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
                {
                    onNoHit?.Invoke();
                    enemy.ChangeStateLogicSM("Rest");
                }
            }
        }

        for (int i = 0; i < attackColliders.Length; i++)
        {
            PlayerData playerData = attackColliders[i].GetComponentInParent<PlayerData>();
            if (playerData)
            {
                onHitPlayer?.Invoke();
                playerData.TakeDamage(damage, null, enemy);
                playerData.KnockBack(knockbackForce, enemy.transform.position, 0);
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
            onHitWall?.Invoke();
            enemy.ChangeStateLogicSM("Rest");
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, rangeAttack);
    }
}