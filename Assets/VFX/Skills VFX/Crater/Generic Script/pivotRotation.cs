using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pivotRotation : MonoBehaviour
{
    public Transform Pivot;
    public float Speed = -10;
    public float MinSpeed = -5f;
    public float DecreaseMultiplier = 2f;
    private float ActualSpeed;
    public TrailRenderer Trail;

    public void OnEnable()
    {
        ActualSpeed = Speed;
    }
    void FixedUpdate()
    {
        transform.RotateAround(Pivot.position, Vector3.up, ActualSpeed);

        if(ActualSpeed < MinSpeed)
        {
            ActualSpeed += DecreaseMultiplier * Time.deltaTime;
        }
    }

    void Rotate(float literalAngle)
    {
        transform.RotateAround(Pivot.position, -Vector2.left, literalAngle - transform.eulerAngles.x);
    }
}
