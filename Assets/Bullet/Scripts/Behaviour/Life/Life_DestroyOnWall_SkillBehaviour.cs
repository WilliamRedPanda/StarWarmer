using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life_DestroyOnWall_SkillBehaviour : BaseSkillBehaviour
{
    Collider[] colliders;
    bool b;

    //protected override void OnShoot()
    //{
    //    base.OnShoot();
    //    StartCoroutine(PostCheckCollide());
    //}

    RaycastHit hit;

    protected override void FixedTick()
    {
        base.FixedTick();
        colliders = Physics.OverlapSphere(skill.transform.position, 0.1f);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].tag == "Wall")
            {
                skill.Return();
            }
        }

        //if (Physics.SphereCast(skill.transform.position, 0.1f, Vector3.zero, out hit, 0.11f))
        //{
        //    if (hit.transform.tag == "Wall")
        //    {
        //        skill.Return();
        //    }
        //}
    }

    //IEnumerator PostCheckCollide()
    //{
    //    yield return new WaitForSeconds(0.1f);
    //    b = true;
    //}

    //protected override void OnEnterCollider(Collider other)
    //{
    //    base.OnEnterCollider(other);
    //    if (other.tag == "Wall" && b)
    //    {
    //        skill.Return();
    //    }
    //}

    //protected override void OnReturn()
    //{
    //    base.OnReturn();
    //    StopCoroutine(PostCheckCollide());
    //    b = false;
    //}
}
