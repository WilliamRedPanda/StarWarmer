using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputListUI : MonoBehaviour
{
    [SerializeField] PlayerControllerInput controller;
    [SerializeField] GameObject panel;

    private void Start()
    {
        controller.OnInputPressed += Open;
        controller.OnInputReset += Close;
    }

    void Open(InputData inputData)
    {
        panel.SetActive(true);
    }

    void Close()
    {
        panel.SetActive(false);
    }
}
