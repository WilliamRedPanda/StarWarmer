using UnityEngine;
using System.Collections;

namespace StateMachine.Gameplay
{
    public class Gameplay_Pause_State : Gameplay_Base_State
    {
        float currentTimeScale;

        public override void Enter()
        {
            base.Enter();
            currentTimeScale = Time.timeScale;
            Time.timeScale = 0f;
        }

        public override void Tick()
        {
            base.Tick();
            context.playerController.pause.HandleInput();
        }

        public override void Exit()
        {
            base.Exit();
            Time.timeScale = currentTimeScale;
            SoundManager.instance.Play("MenuBack");
        }
    }
}