using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown(KeyCode.JoystickButton4))
        {
            OpenClose();
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