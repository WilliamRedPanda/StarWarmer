using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life_DestroyOnWall_SkillBehaviour : BaseSkillBehaviour
{
    protected override void OnEnterCollider(Collider other)
    {
        base.OnEnterCollider(other);
        if (other.tag == "Wall")
        {
            skill.Return();
        }
    }
}
