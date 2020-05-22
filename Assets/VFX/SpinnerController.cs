using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpinnerController : MonoBehaviour
{
    ParticleSystem ps;
    ParticleSystemRenderer psr;
    ParticleSystem.VelocityOverLifetimeModule vel;
    float yPositionOver = 1f;
    float yPositionUnder = -0.02f;
    float speedVariation = 0.0f;
    public int acceleration = 1;
    float h, v;
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        psr = ps.GetComponent<ParticleSystemRenderer>();
        vel = ps.velocityOverLifetime;
        vel.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current != null)
        {
            h = Keyboard.current.aKey.ReadValue() * -1 + Keyboard.current.dKey.ReadValue();
            v = Keyboard.current.sKey.ReadValue() * -1 + Keyboard.current.wKey.ReadValue();
        }

        if (Gamepad.current != null)
        {
            h = Gamepad.current.leftStick.x.ReadValue();
            v = Gamepad.current.leftStick.y.ReadValue();
        }

        if (h > 0 && speedVariation <= 2.5f)
        {
            speedVariation += Time.deltaTime * acceleration;
            vel.orbitalY = new ParticleSystem.MinMaxCurve(speedVariation);
        }
        else if (h < 0 && speedVariation >= -2.5f)
        {
            speedVariation -= Time.deltaTime * acceleration;
            vel.orbitalY = new ParticleSystem.MinMaxCurve(speedVariation);
        }
        if (v > 0 && gameObject.transform.position.y < 0)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, yPositionOver, gameObject.transform.position.z);
            psr.sortingOrder = 6;
        }
        else if (v < 0 && gameObject.transform.position.y > 0)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, yPositionUnder, gameObject.transform.position.z);
            psr.sortingOrder = 4;
        }
    }
}
