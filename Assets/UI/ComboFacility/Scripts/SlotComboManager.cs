using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotComboManager : MonoBehaviour
{
    [SerializeField] SelectableComboManager selectableManager;
    [SerializeField] ComboFacility comboFacility;
    [SerializeField] Button[] SlotButtons;
    [SerializeField] ComboSlot[] slots;

    public void Select(int slotIndex)
    {
        selectableManager.gameObject.SetActive(true);
        comboFacility.currentSlot = slotIndex;
        OpenSelectable();
        SoundManager.instance.Play("MenuSelection");
    }

    void OpenSelectable()
    {
        comboFacility.OpenSelectable();
    }

    public void InteractiveButtons(bool _interactive)
    {
        for (int i = 0; i < SlotButtons.Length; i++)
        {
            SlotButtons[i].interactable = _interactive;
        }
    }

    public void ChangeSlotView(int index, SetSequences set)
    {
        slots[index].ChangeSkill(set);
    }
}