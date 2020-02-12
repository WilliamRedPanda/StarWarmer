using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboUI : MonoBehaviour
{
    [SerializeField] Image comboIconImage;
    [SerializeField] Image cooldownBarImage;
    [SerializeField] Image expBarImage;
    [SerializeField] Transform comboListTransform;
    [SerializeField] Image IconPrefab;
    [SerializeField] inputDevice inputDevice;

    SetSequences combo;
    float deltaCooldown, deltaExp;

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
            for (int i = 0; i < _combo.level; i++)
            {
                foreach (var input in _combo.commands[i].data.inputDatas)
                {
                    Image inputImage = Instantiate(IconPrefab, comboListTransform);
                    if (inputDevice == inputDevice.keyboard) inputImage.sprite = input.keySprite;
                    else if (inputDevice == inputDevice.xBox) inputImage.sprite = input.XboxSprite;
                    else if (inputDevice == inputDevice.playStation) inputImage.sprite = input.PSSprite;
                }
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