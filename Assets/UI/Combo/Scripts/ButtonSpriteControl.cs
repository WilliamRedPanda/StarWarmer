using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSpriteControl : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] Image HighlightSprite;

    InputData input;

    public void Set(InputData _index)
    {
        input = _index;
    }

    public void SetSprite(inputDevice inputDevice)
    {
        switch (inputDevice)
        {
            case inputDevice.keyboard:
                image.sprite = input.keySprite;
                break;
            case inputDevice.playStation:
                image.sprite = input.PSSprite;
                break;
            case inputDevice.xBox:
                image.sprite = input.XboxSprite;
                break;
            default:
                break;
        }
    }

    public void SetSprite(Sprite _sprite)
    {
        image.sprite = _sprite;
    }

    public void Highlight(bool _b)
    {
        HighlightSprite.enabled = _b;
    }
}