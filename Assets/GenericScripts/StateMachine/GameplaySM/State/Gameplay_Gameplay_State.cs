using UnityEngine;
using System.Collections;

namespace StateMachine.Gameplay
{
    public class Gameplay_Gameplay_State : Gameplay_Base_State
    {
        public override void Tick()
        {
            base.Tick();
            //TEMP: Dividere le state machine di menu e di gameplay e togliere questo aborto
            if (context.playerController)
            {
                context.playerController.HandlePlayer();
                context.playerController.pause.HandleInput();
                context.playerController.comboFacility.HandleInput();
            }
            else
                context.playerController = FindObjectOfType<PlayerControllerInput>();

            
        }
    }
}