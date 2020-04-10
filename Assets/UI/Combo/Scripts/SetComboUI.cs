using UnityEngine;
using System.Collections;
using System;

public class SetComboUI : MonoBehaviour
{
    [SerializeField] PlayerInputInstance player;
    [SerializeField] ComboUI comboUI;
    [SerializeField] [Range(0, 2)] int index;

    int indexCurrentInput;
    private void Start()
    {
        comboUI.SetCombo(player.instance.sequences[index]);
        player.instance.OnEndSetupSequence += ChangeCombo;
    }

    private void ChangeCombo()
    {
        comboUI.SetCombo(player.instance.sequences[index]);
    }
}