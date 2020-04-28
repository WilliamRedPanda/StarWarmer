using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentSequenceUI : MonoBehaviour
{
    [SerializeField] PlayerControllerInput controller;
    [SerializeField] CurrentControllerManager controllerManager;

    [SerializeField] Transform box;
    [SerializeField] ButtonSpriteControl iconPrefab;

    [SerializeField] inputDevice inputDevice;

    Queue<ButtonSpriteControl> inputImage;

    private void Start()
    {
        inputImage = new Queue<ButtonSpriteControl>();
        controller.OnInputPressed += UpdateInput;
        controller.OnInputReset += ResetInputView;
        controllerManager.OnChangeController += ChangeDevice;
    }

    private void OnDisable()
    {
        controller.OnInputPressed -= UpdateInput;
        controller.OnInputReset -= ResetInputView;
        controllerManager.OnChangeController -= ChangeDevice;
    }

    void ChangeDevice(inputDevice _inputDevice)
    {
        inputDevice = _inputDevice;
    }

    void UpdateInput(InputData _input)
    {
        ButtonSpriteControl image;
        image = Instantiate(iconPrefab, box);
        switch (inputDevice)
        {
            case inputDevice.keyboard:
                image.SetSprite(_input.keySprite);
                break;
            case inputDevice.playStation:
                image.SetSprite(_input.PSSprite);
                break;
            case inputDevice.xBox:
                image.SetSprite(_input.XboxSprite);
                break;
            default:
                break;
        }
        inputImage.Enqueue(image);
    }

    void ResetInputView()
    {
        int inputImageL = inputImage.Count;
        for (int i = 0; i < inputImageL; i++)
        {
            Destroy(inputImage.Dequeue().gameObject);
        }
    }
}
