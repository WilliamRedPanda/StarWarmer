using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSpriteControlWorldPos : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] InputData inputData;
    [SerializeField] CurrentControllerManager currentControllerManager;

    private void OnEnable()
    {
        currentControllerManager.OnChangeController += SetSprite;
    }

    private void OnDisable()
    {
        currentControllerManager.OnChangeController -= SetSprite;
    }

    public void SetSprite(inputDevice inputDevice)
    {
        switch (inputDevice)
        {
            case inputDevice.keyboard:
                spriteRenderer.sprite = inputData.keySprite;
                break;
            case inputDevice.playStation:
                spriteRenderer.sprite = inputData.PSSprite;
                break;
            case inputDevice.xBox:
                spriteRenderer.sprite = inputData.XboxSprite;
                break;
            default:
                break;
        }
    }
}