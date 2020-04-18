using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotComboManager : MonoBehaviour
{
    [SerializeField] SelectableComboManager selectableManager;
    [SerializeField] ComboFacility comboFacility;

    public void Select(int slotIndex)
    {
        selectableManager.gameObject.SetActive(true);
        comboFacility.currentSlot = slotIndex;
        OpenSelectable();
    }

    void OpenSelectable()
    {
        comboFacility.OpenSelectable();
    }
}