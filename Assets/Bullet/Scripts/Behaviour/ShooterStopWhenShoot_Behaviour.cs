using UnityEngine;

public class ShooterStopWhenShoot_Behaviour : BaseSkillBehaviour
{
    [SerializeField] float time;

    protected override void OnShoot()
    {
        base.OnShoot();
        CharacterBase c = skill.shooter.gameObject.GetComponent<CharacterBase>();
        if (c)
            c.Stop(time);
    }
}