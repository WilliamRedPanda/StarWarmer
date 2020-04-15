using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life_DestroyOnDamage_SkillBehaviour : BaseSkillBehaviour
{
    protected override void OnPostDamage()
    {
        base.OnPostDamage();
        skill.Return();
    }
}