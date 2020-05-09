using UnityEngine;
using System.Collections;

namespace StateMachine.Gameplay
{
    public class Gameplay_Gameplay_State : Gameplay_Base_State
    {
        [SerializeField] AudioClip dungeonAudioClip;

        public override void Enter()
        {
            base.Enter();
            SoundManager.instance.Play(dungeonAudioClip);
        }

        public override void Tick()
        {
            base.Tick();
            //TEMP: Dividere le state machine di menu e di gameplay e togliere questo aborto
            if (context.playerController)
            {
                context.playerController.HandlePlayer();
                context.playerController.pause.HandleInput();
                //context.playerController.comboFacility.HandleInput();
            }
            else
                context.playerController = FindObjectOfType<PlayerControllerInput>();
        }

        public override void Exit()
        {
            base.Exit();
            SoundManager.instance.Pause(dungeonAudioClip);
        }
    }
}