using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : CharacterBase
{
    protected override void Awake()
    {
        base.Awake();
        OnDeath += Death;
    }

    void Death(IDamageable damageable)
    {
        damageable.Heal();
    }
}
