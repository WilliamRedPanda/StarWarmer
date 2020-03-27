using UnityEngine;
using System.Collections;

public class Stun_OnDamage_Behaviour : BaseSkillBehaviour
{
    [SerializeField] float time;

    protected override void OnDamage(IDamageable _damageable)
    {
        base.OnDamage(_damageable);
        _damageable.Stun(time);
    }
}