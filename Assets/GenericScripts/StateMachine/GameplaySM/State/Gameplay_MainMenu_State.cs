using UnityEngine;
using System.Collections;

namespace StateMachine.Gameplay
{
    public class Gameplay_MainMenu_State : Gameplay_Base_State
    {
        [SerializeField] AudioClip menuClip;

        public override void Enter()
        {
            base.Enter();
            SoundManager.instance.Play(menuClip);
        }

        public override void Exit()
        {
            base.Exit();
            SoundManager.instance.Pause(menuClip);
        }
    }
}