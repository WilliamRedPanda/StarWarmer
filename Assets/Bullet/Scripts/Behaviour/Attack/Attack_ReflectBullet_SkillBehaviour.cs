using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_ReflectBullet_SkillBehaviour : BaseSkillBehaviour
{
    BulletBase otherBullet;
    GenericEnemy genericEnemy;

    protected override void OnEnterCollider(Collider other)
    {
        base.OnEnterCollider(other);

        otherBullet = other.gameObject.GetComponentInParent<BulletBase>();

        if (otherBullet)
        {
            if (otherBullet.shooter != skill.shooter)
            {
                otherBullet.Return();
                //otherBullet.Reflect();
            }
        }
    }
}