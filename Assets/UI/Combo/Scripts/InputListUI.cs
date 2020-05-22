using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputListUI : MonoBehaviour
{
    [SerializeField] PlayerControllerInput controller;
    [SerializeField] GameObject[] panels;

    private void Start()
    {
        //controller.OnInputPressed += Open;
        //controller.OnInputReset += Close;

        Close();
    }

    private void Update()
    {
        if (Keyboard.current != null)
        {
            if (Keyboard.current.tabKey.wasPressedThisFrame)
            {
                OpenClose();
            }
        }

        if (Gamepad.current != null)
        {
            if (Gamepad.current.leftShoulder.wasPressedThisFrame)
            {
                OpenClose();
            }
        }
    }

    void Open(InputData inputData)
    {
        for (int i = 0; i < panels.Length; i++)
        {
            panels[i].SetActive(true);
        }
    }

    void Close()
    {
        for (int i = 0; i < panels.Length; i++)
        {
            panels[i].SetActive(false);
        }
    }

    void OpenClose()
    {
        for (int i = 0; i < panels.Length; i++)
        {
            panels[i].SetActive(!panels[i].activeSelf);
        }
    }
}