using UnityEngine;
using System.Collections;

namespace StateMachine.Gameplay
{
    public class Gameplay_ComboFacility_State : Gameplay_Base_State
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
            context.playerController.comboFacility.HandleInput();
        }

        public override void Exit()
        {
            base.Exit();
            Time.timeScale = currentTimeScale;
        }
    }
}