using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim_AutoAimCircle_Behaviour : BaseSkillBehaviour
{
    [SerializeField] float range;

    CharacterBase enemy;

    protected override void OnPreShoot()
    {
        base.OnPreShoot();
        Vector3 shooterPosition = skill.shooter.transform.position;
        Collider[] colliders = Physics.OverlapSphere(skill.shooter.transform.position, range);
        for (int i = 0; i < colliders.Length; i++)
        {
            CharacterBase enemyTemp = colliders[i].GetComponentInParent<CharacterBase>();

            if (enemyTemp == null) continue;

            if (enemyTemp.gameObject.GetComponent<PlayerData>()) continue;

            if (skill.target == null)
            {
                skill.target = enemyTemp.transform.position;
                enemy = enemyTemp;
                continue;
            }

            if (Vector3.Distance(shooterPosition, enemyTemp.transform.position) < Vector3.Distance(shooterPosition, skill.target))
            {
                skill.target = enemyTemp.transform.position;
                enemy = enemyTemp;
                continue;
            }
        }

        if (enemy == null)
        {
            int[] choice = { -1, 1 };
            int i = choice[Random.Range(0,choice.Length)];
            skill.target = skill.shooter.transform.position + (Vector3.right * range * i);
        }
    }

    protected override void OnReturn()
    {
        base.OnReturn();
        enemy = null;
        skill.target = Vector3.zero;
    }
}