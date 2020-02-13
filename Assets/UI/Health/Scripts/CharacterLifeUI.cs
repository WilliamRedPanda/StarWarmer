using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterLifeUI : MonoBehaviour
{
    [SerializeField] CharacterBase character;
    [SerializeField] Image slider;

    private void Start()
    {
        character.OnDamage += FillSlider;
    }

    void FillSlider(int _damage, CommandSequence _command)
    {
        slider.fillAmount = (float)character.currentHealth / (float)character.maxHealth;
    }
}