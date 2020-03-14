using StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace StateMachine.Gameplay
{
    public class GameplaySM : StateMachineBase<GameplaySMContext>
    {
        [SerializeField] CurrentScene currentScene = CurrentScene.gameplay;
        [SerializeField] PlayerInputInstance playerData;

        public static GameplaySM instance { get; private set; }

        protected override void Awake()
        {
            base.Awake();
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);

                switch (currentScene)
                {
                    case CurrentScene.mainMenu:
                        instance.Go("MainMenu");
                        break;
                    case CurrentScene.gameplay:
                        instance.Go("Gameplay");
                        break;
                    default:
                        break;
                }
            }
            else
            {
                Destroy(gameObject);
            }

        }

        protected override void SetContext()
        {
            currentContext = new GameplaySMContext()
            {
                playerController = playerData.instance,
                BaseExit = GoNext,
                Exit = Go,
            };
        }

        public void GoNext()
        {
            instance.SM.SetTrigger("Next");
        }

        IEnumerator WaitLoad(string _s)
        {
            while(!SceneManager.GetActiveScene().isLoaded)
            {
                yield return null;
            }
            Go(_s);
        }

        public void Go(string _trigger)
        {
            if (SceneManager.GetActiveScene().isLoaded)
                instance.SM.SetTrigger(_trigger);
            else
                StartCoroutine(WaitLoad(_trigger));
        }
    }

    public class GameplaySMContext : IStateMachineContext
    {
        public System.Action BaseExit;
        public System.Action<string> Exit;
        public PlayerControllerInput playerController;
    }

    public enum CurrentScene
    {
        mainMenu,
        gameplay,
    }
}