﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Path_EnemyBehaviour : BaseEnemyBehaviour
{
    [SerializeField] Transform[] path;
    [SerializeField] float speed;
    [SerializeField] bool patrol, aggro;

    int index = 0;
    Vector3 newPos;

    protected override void OnEnable()
    {
        base.OnEnable();
        newPos = enemy.transform.position;
    }

    protected override void PatrolTick()
    {
        if (patrol)
        {
            base.PatrolTick();
            Handler();
        }
    }

    protected override void AggroTick()
    {
        if (aggro)
        {
            base.AggroTick();
            Handler();
        }
    }

    Collider[] colliders;
    bool moving;

    void Handler()
    {
        if (path.Length == 0)
            return;

        if (path[index] == null)
        {
            AddIndex();
            return;
        }

        enemy.moving = true;

        enemy.transformVelocity = (path[index].position - enemy.transform.position).normalized * speed * Time.fixedDeltaTime;

        colliders = Physics.OverlapSphere(path[index].position, 0.05f);

        foreach (var item in colliders)
        {
            GenericEnemy enemyCollider = item.GetComponentInParent<GenericEnemy>();
            if (enemyCollider != null)
            {
                if (enemyCollider == enemy)
                {
                    AddIndex();
                }
            }
        }
        //if (Vector3.Distance(enemy.transform.position, path[index].position) < 0.1f)
        //{
        //    AddIndex();
        //}
    }

    void AddIndex()
    {
        index++;
        if (index >= path.Length)
            index = 0;
    }
}