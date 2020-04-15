using UnityEngine;

public class ShooterStopWhenShoot_SkillBehaviour : BaseSkillBehaviour
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