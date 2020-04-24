using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_LookPlayerAimDirection_SkillBehaviour : BaseSkillBehaviour
{
    protected override void Tick()
    {
        base.Tick();

        if (skill.reflect)
            transform.rotation = Quaternion.LookRotation(-skill.shooter.aimDirection);
        else
            transform.rotation = Quaternion.LookRotation(skill.shooter.aimDirection);
    }
}