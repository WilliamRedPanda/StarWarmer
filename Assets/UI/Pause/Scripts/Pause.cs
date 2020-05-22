using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Pause : MonoBehaviour
{
    [SerializeField] Transform panel;
    
    bool pause;
    float currentTimeScale;

    public void HandleInput()
    {
        if (Keyboard.current != null)
        {
            if (Keyboard.current.escapeKey.wasPressedThisFrame)
            {
                PauseAndResume();
            }
        }

        if (Gamepad.current != null)
        {
            if(Gamepad.current.startButton.wasPressedThisFrame)
            {
                PauseAndResume();
            }
        }
    }

    public void PauseAndResume()
    {
        pause = !pause;
        panel.gameObject.SetActive(pause);
        if (pause)
        {
            StateMachine.Gameplay.GameplaySM.instance.Go("Pause");
        }
        else
        {
            StateMachine.Gameplay.GameplaySM.instance.Go("Gameplay");
        }
    }
}