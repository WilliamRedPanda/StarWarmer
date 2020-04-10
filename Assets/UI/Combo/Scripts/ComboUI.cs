using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class ComboUI : MonoBehaviour
{
    [SerializeField] Image comboIconImage;
    [SerializeField] Image cooldownBarImage;
    [SerializeField] Image expBarImage;
    [SerializeField] Transform comboListTransform;
    [SerializeField] bool highlighted;
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI descriptionText;
    [SerializeField] Image[] levelIcon;
    [SerializeField] ButtonSpriteControl iconPrefab;
    [SerializeField] inputDevice inputDevice;

    [HideInInspector] public SetSequences combo;
    float deltaCooldown, deltaExp;

    List<ButtonSpriteControl> inputIcons = new List<ButtonSpriteControl>();
    int currentInputIndex;

    float timer;

    void SubscribeEvent()
    {
        if (expBarImage) combo.onAddExp += SetExpBar;
        if (cooldownBarImage) combo.onCooldownChange += SetCooldownBar;
        if (highlighted)
        {
            if (comboListTransform) combo.playerController.OnInputReset += RemoveHighlight;
        }
    }

    void UnsubscribeEvent()
    {
        if (expBarImage) combo.onAddExp -= SetExpBar;
        if (cooldownBarImage) combo.onCooldownChange -= SetCooldownBar;
        if (highlighted)
        {
            if (comboListTransform)
            {
                combo.playerController.OnInputReset -= RemoveHighlight;
                for (int i = 0; i < combo.level; i++)
                {
                    combo.commands[i].onCorrectInput -= Highlight;
                }
            }
        }
    }

    bool b;
    public void SetCombo(SetSequences _combo)
    {
        if (combo != null)
            UnsubscribeEvent();
        currentInputIndex = 0;
        combo = _combo;
        timer = combo.data.cooldown;
        if (comboIconImage) comboIconImage.sprite = combo.data.icon;
        deltaCooldown = 1f / (float)combo.data.cooldown;
        if (combo.levelMaxed)
            deltaExp = 1;
        else
            deltaExp = 1f / (float)combo.data.combosData[combo.level].NecessaryExp;
        if (expBarImage)
            SetExpBar();

        if (comboListTransform)
        {
            RemoveInputs();

            for (int i = 0; i < _combo.level; i++)
            {
                if (highlighted)
                    _combo.commands[i].onCorrectInput += Highlight;
                foreach (var input in _combo.commands[i].data.inputDatas)
                {
                    ButtonSpriteControl inputImage = Instantiate(iconPrefab, comboListTransform);
                    inputIcons.Add(inputImage);
                    if (inputDevice == inputDevice.keyboard) inputImage.SetSprite(input.keySprite);
                    else if (inputDevice == inputDevice.xBox) inputImage.SetSprite(input.XboxSprite);
                    else if (inputDevice == inputDevice.playStation) inputImage.SetSprite(input.PSSprite);

                }
            }
        }

        if (nameText)
            nameText.text = combo.data.name;

        if (descriptionText)
            descriptionText.text = combo.data.description;

        for (int i = 0; i < levelIcon.Length; i++)
        {
            if (combo.level > i)
                levelIcon[i].gameObject.SetActive(true);
            else
                levelIcon[i].gameObject.SetActive(false);
        }

        SubscribeEvent();
    }

    void RemoveInputs()
    {
        if (inputIcons.Count > 0)
        {
            ButtonSpriteControl _image;
            for (int i = inputIcons.Count - 1; i >= 0; i--)
            {
                _image = inputIcons[i];
                inputIcons.RemoveAt(i);
                Destroy(_image.gameObject);
            }
        }
    }

    void Highlight(InputData input)
    {
        inputIcons[currentInputIndex].Highlight(true);
        currentInputIndex++;
    }

    void RemoveHighlight()
    {
        for (int i = 0; i < inputIcons.Count; i++)
        {
            inputIcons[i].Highlight(false);
        }
        currentInputIndex = 0;
    }

    
    public void SetCooldownBar(float _time)
    {
        cooldownBarImage.fillAmount = 1 - (deltaCooldown * _time);
        
        timer -= _time;
        if (timer == 0)
            timer = combo.data.cooldown;
    }

    public void SetExpBar()
    {
        expBarImage.fillAmount = deltaExp * (float)combo.exp;
    }
}