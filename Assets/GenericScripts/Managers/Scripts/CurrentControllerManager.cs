using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.XR;

[CreateAssetMenu(fileName = "ControllerManager", menuName = "Data/Manager/ControllerManager")]
public class CurrentControllerManager : ScriptableObject
{
    public inputDevice currentController { get; private set; }
    public Action<inputDevice> OnChangeController;

    public void ChangeController(inputDevice _controllerType)
    {
        currentController = _controllerType;
        OnChangeController.Invoke(currentController);
    }
}