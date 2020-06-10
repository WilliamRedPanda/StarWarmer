 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GenericEvent_SkillBehaviour : BaseSkillBehaviour
{
    [SerializeField] UnityEvent onShoot;
    [SerializeField] UnityEvent onCollideCharacter;
    [SerializeField] UnityEvent onCollideWall;
    [SerializeField] UnityEvent onDisable;

    protected override void OnShoot()
    {
        base.OnShoot();
        onShoot?.Invoke();
    }

    protected override void OnEnterCollider(Collider other)
    {
        base.OnEnterCollider(other);
        CharacterBase character = other.GetComponent<CharacterBase>();
        if (character)
        {
            onCollideCharacter?.Invoke();
        }
        else if (other.gameObject.tag == "Wall")
        {
            onCollideWall?.Invoke();
        }
    }

    protected override void OnReturn()
    {
        base.OnReturn();
        onDisable?.Invoke();
    }
}