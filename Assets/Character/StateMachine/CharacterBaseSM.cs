using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine.Character
{
    public class CharacterBaseSM : StateMachineBase<CharacterBaseSMContext>
    {
        [SerializeField] CharacterBase character;
        [SerializeField] PlayerControllerInput playerInput;

        protected override void SetContext()
        {
            currentContext = new CharacterBaseSMContext()
            {
                character = character,
                playerInput = playerInput,
            };
        }
    }

    public class CharacterBaseSMContext : IStateMachineContext
    {
        public CharacterBase character;
        public PlayerControllerInput playerInput;
    }
}