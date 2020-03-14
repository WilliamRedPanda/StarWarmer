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
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI descriptionText;
    [SerializeField] Image[] levelIcon;
    [SerializeField] Image iconPrefab;
    [SerializeField] inputDevice inputDevice;

    [HideInInspector] public SetSequences combo;
    float deltaCooldown, deltaExp;

    List<Image> inputIcons = new List<Image>();

    void SubscribeEvent()
    {
        if (expBarImage) combo.onAddExp += SetExpBar;
        if (cooldownBarImage) combo.onCooldownChange += SetCooldownBar;
    }

    void UnsubscribeEvent()
    {
        if (expBarImage) combo.onAddExp -= SetExpBar;
        if (cooldownBarImage) combo.onCooldownChange -= SetCooldownBar;
    }

    public void SetCombo(SetSequences _combo)
    {
        if (combo != null)
            UnsubscribeEvent();
        combo = _combo;
        SubscribeEvent();
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
                foreach (var input in _combo.commands[i].data.inputDatas)
                {
                    Image inputImage = Instantiate(iconPrefab, comboListTransform);
                    inputIcons.Add(inputImage);
                    if (inputDevice == inputDevice.keyboard) inputImage.sprite = input.keySprite;
                    else if (inputDevice == inputDevice.xBox) inputImage.sprite = input.XboxSprite;
                    else if (inputDevice == inputDevice.playStation) inputImage.sprite = input.PSSprite;
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
    }

    void RemoveInputs()
    {
        if (inputIcons.Count > 0)
        {
            Image _image;
            for (int i = inputIcons.Count - 1; i >= 0; i--)
            {
                _image = inputIcons[i];
                inputIcons.RemoveAt(i);
                Destroy(_image.gameObject);
            }
        }
    }

    public void SetCooldownBar(float _time)
    {
        cooldownBarImage.fillAmount = 1 - (deltaCooldown * _time);
    }

    public void SetExpBar()
    {
        expBarImage.fillAmount = deltaExp * (float)combo.exp;
    }
}