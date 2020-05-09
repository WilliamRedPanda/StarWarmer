using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GenericEvent_SkillBehaviour : BaseSkillBehaviour
{
    [SerializeField] UnityEvent onShoot;
    [SerializeField] UnityEvent onCollideCharacter;

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
    }
}