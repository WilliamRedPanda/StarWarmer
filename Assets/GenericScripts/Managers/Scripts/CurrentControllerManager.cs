using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

[CreateAssetMenu(fileName = "ControllerManager", menuName = "Data/Manager/ControllerManager")]
public class CurrentControllerManager : ScriptableObject
{
    public inputDevice currentController { get; private set; }
    public Action<inputDevice> OnChangeController;

    public Gamepad gamepad;
    Gamepad gamepadOfFrameBefore;

    Keyboard keyboard;

    private void OnEnable()
    {
        CheckChangeCurrentDevice();
    }

    public void CheckChangeCurrentDevice()
    {
        gamepad = Gamepad.current;
        keyboard = Keyboard.current;



        if (currentController != inputDevice.keyboard)
        {
            if (keyboard != null)
            {
                if (keyboard.IsPressed(1f))
                {
                    ChangeController(inputDevice.keyboard);
                }
            }
            
            CheckGamepadType();
        }

        if (currentController == inputDevice.keyboard)
        {
            if (gamepad != null)
            {
                if (gamepad.buttonSouth.wasPressedThisFrame || gamepad.buttonWest.wasPressedThisFrame || gamepad.buttonEast.wasPressedThisFrame || gamepad.buttonNorth.wasPressedThisFrame || gamepad.leftStick.ReadValue().magnitude > 0.3f)
                {
                    if (gamepad.name.Contains("4"))
                        ChangeController(inputDevice.playStation);
                    else
                        ChangeController(inputDevice.xBox);
                }
            }
        }
    }

    void CheckGamepadType()
    {
        if (gamepad != null)
        {
            if (gamepad.IsPressed(1f))
            {
                if (gamepadOfFrameBefore != gamepad)
                {
                    if (gamepad.name.Contains("4"))
                        ChangeController(inputDevice.playStation);
                    else
                        ChangeController(inputDevice.xBox);
                }
            }
            gamepadOfFrameBefore = gamepad;
        }
    }

    void ChangeController(inputDevice _controllerType)
    {
        currentController = _controllerType;
        OnChangeController.Invoke(currentController);
    }
}