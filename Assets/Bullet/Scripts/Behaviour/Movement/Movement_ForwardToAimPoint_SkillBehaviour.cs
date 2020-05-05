using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[HelpURL("https://docs.google.com/document/d/1likHtetpfsZksF92lwV5sW-NUmKy3_Zl1zG15DzDZ6k/edit?usp=sharing")]
public class Movement_ForwardToAimPoint_SkillBehaviour : BaseSkillBehaviour
{
    [SerializeField] float speed;

    Vector3 direction;

    protected override void OnShoot()
    {
        base.OnShoot();
        direction = skill.shooter.aimDirection;
    }

    Vector3 v3;

    //protected override void Tick()
    //{
    //    base.Tick();
        
    //    v3 = direction.normalized * Time.fixedDeltaTime * speed;
    //    //skill.transform.position += v3;
    //    skill.SetMove(v3, Space.Self);
    //}

    protected override void FixedTick()
    {
        base.FixedTick();
        v3 = direction.normalized * Time.fixedDeltaTime * speed;
        //skill.transform.position += v3;
        skill.SetMove(v3, Space.Self);
    }
}