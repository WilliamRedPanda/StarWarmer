using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_OneDirection_SkillBehaviour : BaseSkillBehaviour
{
    [SerializeField] Vector3 direction;
    [SerializeField] float speed;

    Vector3 speedVector;
    protected override void OnEnable()
    {
        base.OnEnable();
        speedVector = direction.normalized * speed;
    }

    protected override void Tick()
    {
        base.Tick();
        Vector3 velocity = speedVector * Time.fixedDeltaTime;
        //skill.transform.position += velocity;
        skill.SetMove(velocity, Space.World);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + direction.normalized * speed);
    }
}