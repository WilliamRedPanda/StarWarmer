using StateMachine;
using StateMachine.Gameplay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Gameplay_Win_State : Gameplay_Base_State
{
    [SerializeField] GameObject winUIPrefab;

    PlayerControllerInput playerController;
    GameObject winUI;
    public override void Enter()
    {
        base.Enter();
        context.playerController.ResetVelocity();
        playerController = FindObjectOfType<PlayerControllerInput>();
        winUI = Instantiate(winUIPrefab);
        winUI.GetComponent<Canvas>().worldCamera = playerController.mainCamera.OutputCamera;
    }

    public override void Tick()
    {
        base.Tick();
        if (Keyboard.current != null)
        {
            if (Keyboard.current.enterKey.wasPressedThisFrame || Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                context.Exit("Gameplay");
            }
        }

        if (Gamepad.current != null)
        {
            if (Gamepad.current.buttonSouth.wasPressedThisFrame || Gamepad.current.startButton.wasPressedThisFrame)
            {
                context.Exit("Gameplay");
            }
        }
    }

    public override void Exit()
    {
        base.Exit();
        if (winUI)
            Destroy(winUI);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}