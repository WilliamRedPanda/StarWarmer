using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol_SearchPlayerCircleView_EnemyBehaviour : BaseEnemyBehaviour
{
    [SerializeField] float viewRadious;

    Collider[] colliders;

    protected override void PatrolTick()
    {
        base.PatrolTick();
        colliders = Physics.OverlapSphere(transform.position, viewRadious);

        foreach (var item in colliders)
        {
            PlayerData player = item.GetComponentInParent<PlayerData>();
            if (player != null)
            {
                enemy.target = player;
                enemy.ChangeStateLogicSM("Aggro");
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, viewRadious);
    }
}