using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life_SpawnOffsetFromTarget_SkillBehaviour : BaseSkillBehaviour
{
    [SerializeField]
    [Tooltip("Sposta la posizione di spawn (valore di 0,0,0 equivale alla posizione del Target)")]
    Vector3 offsetPositionOnShoot;

    protected override void OnMiddleShoot()
    {
        base.OnPreShoot();
        skill.transform.position = skill.target + offsetPositionOnShoot;
    }
}