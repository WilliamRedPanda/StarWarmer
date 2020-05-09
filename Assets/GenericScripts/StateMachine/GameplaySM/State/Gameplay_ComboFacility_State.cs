using UnityEngine;
using System.Collections;

namespace StateMachine.Gameplay
{
    public class Gameplay_ComboFacility_State : Gameplay_Base_State
    {
        [SerializeField] AudioClip FacilityAccessClip;
        [SerializeField] AudioClip FacilityBGMClip;

        float currentTimeScale;

        public override void Enter()
        {
            base.Enter();
            SoundManager.instance.Play(FacilityAccessClip);
            SoundManager.instance.Play(FacilityBGMClip);
            currentTimeScale = Time.timeScale;
            Time.timeScale = 0f;
        }

        public override void Tick()
        {
            base.Tick();
            context.playerController.comboFacility.HandleInput();
        }

        public override void Exit()
        {
            base.Exit();
            SoundManager.instance.Pause(FacilityAccessClip);
            SoundManager.instance.Pause(FacilityBGMClip);
            Time.timeScale = currentTimeScale;
        }
    }
}