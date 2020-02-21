using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] Transform panel;
    
    bool pause;
    float currentTimeScale;

    private void Update()
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
            currentTimeScale = Time.timeScale;
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = currentTimeScale;
            StateMachine.Gameplay.GameplaySM.instance.Go("Gameplay");
        }
    }
}
