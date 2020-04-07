﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardBullet : BulletBase
{
    [SerializeField] float speed;
    [SerializeField] float knockbackForce;
    [SerializeField] float explosionRadius;
    [SerializeField] float explosionKnockbackForce;
    [SerializeField] int explosionDamage;

    public override void Shoot(Vector3 shootPosition, Vector3 direction, IShooter _shooter, CommandSequence _command)
    {
        base.Shoot(shootPosition, direction, _shooter, _command);
        transform.rotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z), Vector3.up);
    }

    protected override void Tick()
    {
        base.Tick();
        transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
    }

    public override void OnDamageableCollide(IDamageable damageable)
    {
        base.OnDamageableCollide(damageable);
        damageable.KnockBack(knockbackForce, transform.position, 1f);

        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        for (int i = 0; i < colliders.Length; i++)
        {
            IDamageable _damageable = colliders[i].GetComponentInParent<IDamageable>();
            if (_damageable != null)
            {
                if (_damageable.gameObject == shooter.gameObject)
                    continue;
        
                _damageable.TakeDamage(explosionDamage, null, shooter);
                _damageable.KnockBack(explosionKnockbackForce, transform.position,1f);
            }
        }
        Return();
    }
}