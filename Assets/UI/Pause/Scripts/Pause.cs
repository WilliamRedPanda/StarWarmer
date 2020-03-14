using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] Transform panel;
    
    bool pause;
    float currentTimeScale;

    public void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.JoystickButton7))
        {
            PauseAndResume();
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