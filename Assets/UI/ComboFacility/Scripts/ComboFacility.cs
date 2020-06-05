using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class ComboFacility : MonoBehaviour
{
    [SerializeField] GameObject canvas;
    [SerializeField] PlayerInputInstance playerInput;
    [SerializeField] ComboUI comboUISelected;
    [SerializeField] Button defaultComboSelection;
    [SerializeField] Button defaultComboSlot;
    [SerializeField] SlotComboManager slotComboManager;
    [SerializeField] SelectableComboManager selectableComboManager;

    [HideInInspector] public int currentSlot;

    PlayerData playerData;
    List<SetSequencesData> equippedSkills;
    SetSequencesData selectedSkill;

    private void Start()
    {
        playerData = playerInput.instance.playerData;
        equippedSkills = new List<SetSequencesData>();
        equippedSkills.AddRange(playerData.sequences);
        slotComboManager.gameObject.SetActive(false);
        selectableComboManager.gameObject.SetActive(false);
        slotComboManager.InteractiveButtons(false);
    }

    public void HandleInput()
    {
        if (Keyboard.current != null)
        {
            if (open)
            {
                if (Keyboard.current.enterKey.wasPressedThisFrame || Keyboard.current.escapeKey.wasPressedThisFrame)
                {
                    Confirmed();
                    Close();
                }
            }
            else
            {
                if (Keyboard.current.spaceKey.wasPressedThisFrame)
                    Open();
            }
        }

        if (Gamepad.current != null)
        {
            if (open)
            {
                if (Gamepad.current.startButton.wasPressedThisFrame || Gamepad.current.buttonEast.wasPressedThisFrame)
                {
                    Confirmed();
                    Close();
                }
            }
            else
            {
                if (Gamepad.current.buttonSouth.wasPressedThisFrame)
                    Open();
            }
        }
    }

    bool pause;
    bool open;
    public void OpenClose()
    {
        open = canvas.activeSelf;
        canvas.SetActive(!open);
        if (open)
        {
            Confirmed();
            StateMachine.Gameplay.GameplaySM.instance.Go("Gameplay");
        }
        else
        {
            slotComboManager.gameObject.SetActive(true);
            selectableComboManager.gameObject.SetActive(false);
            StateMachine.Gameplay.GameplaySM.instance.Go("ComboFacility");
        }
    }

    public void Open()
    {
        slotComboManager.InteractiveButtons(false);
        open = true;
        canvas.SetActive(true);
        slotComboManager.gameObject.SetActive(true);
        selectableComboManager.gameObject.SetActive(false);
        StateMachine.Gameplay.GameplaySM.instance.Go("ComboFacility");
        StartCoroutine(ActiveButton());
    }

    IEnumerator ActiveButton()
    {
        yield return new WaitForSecondsRealtime(1f);
        defaultComboSelection.interactable = true;
        slotComboManager.InteractiveButtons(true);
        defaultComboSelection.Select();
    }

    public void Close()
    {
        Confirmed();
        open = false;
        StateMachine.Gameplay.GameplaySM.instance.Go("Gameplay");
        canvas.SetActive(false);
        SoundManager.instance.Play("MenuBack");
    }

    public void ChangeEquipSkillConfirmed()
    {
        playerInput.instance.playerData.ChangeSkill(equippedSkills);
    }
    
    public void ChangeEquipSkill(int slotIndex, SetSequencesData set)
    {
        set.Instance.Equip(playerInput.instance);
        equippedSkills[slotIndex] = set;
        slotComboManager.ChangeSlotView(slotIndex, set.Instance);
        ChangeEquipSkillConfirmed();
    }

    public void SelectSkill(SetSequencesData _skill)
    {
        selectedSkill = _skill;
        defaultComboSlot.Select();
    }

    public void ChangeCurrentSkillView (SetSequencesData _skill)
    {
        comboUISelected.SetCombo(_skill.Instance);
    }

    public SetSequencesData GetSelectedSkill()
    {
        return selectedSkill;
    }

    public void ResetSelectedSkill()
    {
        selectedSkill = null;
        selectableComboManager.ResetSet();
        selectableComboManager.gameObject.SetActive(false);
        slotComboManager.gameObject.SetActive(true);
    }

    public void Confirmed()
    {
        ChangeEquipSkillConfirmed();
        //OpenClose();
    }

    public void OpenSelectable()
    {
        selectableComboManager.gameObject.SetActive(true);
        selectableComboManager.Reposition();
        defaultComboSelection.Select();
    }
}