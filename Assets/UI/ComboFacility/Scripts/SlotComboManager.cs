using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class SlotComboManager : MonoBehaviour
{
    [SerializeField] SelectableComboManager selectableManager;
    [SerializeField] ComboFacility comboFacility;
    [SerializeField] Button[] SlotButtons;
    [SerializeField] ComboSlot[] slots;
    [SerializeField] Sprite spriteHighlight;

    int index;

    private void Start()
    {
        foreach (var slot in slots)
        {
            slot.imageHighlight.sprite = spriteHighlight;
            //slot.imageHighlight.enabled = false;
        }
    }

    private void Update()
    {
        if (Gamepad.current != null)
        {
            if (Gamepad.current.dpad.down.wasPressedThisFrame || Gamepad.current.leftStick.down.wasPressedThisFrame)
            {
                Next();
            }
            else if (Gamepad.current.dpad.up.wasPressedThisFrame || Gamepad.current.leftStick.up.wasPressedThisFrame)
            {
                Prev();
            }
        }

        if (Keyboard.current != null)
        {
            if (Keyboard.current.downArrowKey.wasPressedThisFrame)
            {
                Next();
            }
            else if (Keyboard.current.upArrowKey.wasPressedThisFrame)
            {
                Prev();
            }
        }
    }

    void Next()
    {
        //slots[index].imageHighlight.enabled = false;
        index++;
        if (index > 2)
        {
            index = 0;
        }
        Highlight(index);
    }

    void Prev()
    {
        //slots[index].imageHighlight.enabled = false;
        index--;
        if (index < 0)
        {
            index = 2;
        }
        Highlight(index);
    }

    void Highlight(int i)
    {
        slots[i].Highlight();
    }

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
        if (_interactive == true)
            SlotButtons[0].Select();
        //for (int i = 0; i < SlotButtons.Length; i++)
        //{
        //    SlotButtons[i].interactable = _interactive;
        //}
    }

    public void ChangeSlotView(int index, SetSequences set)
    {
        slots[index].ChangeSkill(set);
    }
}