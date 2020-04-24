using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_ForwardToSelfRotation_SkillBehaviour : BaseSkillBehaviour
{
    [SerializeField] float speed;

    Vector3 v3;
    protected override void Tick()
    {
        base.Tick();
        //skill.transform.position += transform.forward * Time.deltaTime * speed;
        v3 = transform.forward * Time.fixedDeltaTime * speed;
        skill.SetMove(v3, Space.Self);
    }
}