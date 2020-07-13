using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFX_OnDamage_Behaviour : BaseSkillBehaviour
{
    [SerializeField] ParticleSystem vfxPrefab;
    [SerializeField] Transform vfxPosition;

    ParticleSystem vfx;

    protected override void OnDamage(IDamageable _damageable)
    {
        base.OnShoot();
        vfx = Instantiate(vfxPrefab.gameObject, vfxPosition ? vfxPosition.position : skill.transform.position, Quaternion.LookRotation(skill.shooter.aimDirection)).GetComponent<ParticleSystem>();
        vfx.Play();
        StartCoroutine(Corutine());
    }

    IEnumerator Corutine()
    {
        yield return new WaitForSeconds(vfx.main.duration);
        if (vfx)
            Destroy(vfx.gameObject);
    }
}