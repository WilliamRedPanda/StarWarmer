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
        character.OnHealthChange += FillSlider;
    }

    void FillSlider(int _health)
    {
        slider.fillAmount = (float)character.currentHealth / (float)character.maxHealth;
    }
}