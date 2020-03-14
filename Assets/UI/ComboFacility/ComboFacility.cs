using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ComboFacility : MonoBehaviour
{
    [SerializeField] GameObject canvas;
    [SerializeField] PlayerInputInstance playerInput;
    [SerializeField] ComboUI comboUISelected;
    [SerializeField] Button defaultComboSelection;
    [SerializeField] Button defaultComboSlot;

    PlayerData playerData;
    List<SetSequencesData> equippedSkills;
    SetSequencesData selectedSkill;

    private void Awake()
    {
        playerData = playerInput.instance.playerData;
        equippedSkills = new List<SetSequencesData>();
        equippedSkills.AddRange(playerData.sequences);
    }

    private void Start()
    {
        playerData = playerInput.instance.playerData;
    }

    public void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.JoystickButton7))
            Confirmed();

        if (Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown(KeyCode.JoystickButton6))
        {
            OpenClose();
        }
    }

    bool pause;
    public void OpenClose()
    {
        bool open = canvas.activeSelf;
        canvas.SetActive(!open);
        if (open)
        {
            StateMachine.Gameplay.GameplaySM.instance.Go("Gameplay");
        }
        else
        {
            StateMachine.Gameplay.GameplaySM.instance.Go("ComboFacility");
            defaultComboSelection.Select();
        }

        //pause = !pause;
        //canvas.gameObject.SetActive(pause);
        //if (pause)
        //{
        //    StateMachine.Gameplay.GameplaySM.instance.Go("ComboFacility");
        //    defaultComboSelection.Select();
        //}
        //else
        //{
        //    StateMachine.Gameplay.GameplaySM.instance.Go("Gameplay");
        //}
    }

    public void Close()
    {
        StateMachine.Gameplay.GameplaySM.instance.Go("Gameplay");
        canvas.SetActive(false);
    }

    public void ChangeEquipSkillConfirmed()
    {
        playerInput.instance.playerData.ChangeSkill(equippedSkills);
    }
    
    public void ChangeEquipSkill(int slotIndex, SetSequencesData set)
    {
        equippedSkills[slotIndex] = set;
    }

    public void SelectSkill(SetSequencesData _skill)
    {
        selectedSkill = _skill;
        if (selectedSkill != null)
        {
            comboUISelected.SetCombo(_skill.Instance);
        }
        defaultComboSlot.Select();
    }

    public SetSequencesData GetSelectedSkill()
    {
        return selectedSkill;
    }

    public void ResetSelectedSkill()
    {
        selectedSkill = null;
        defaultComboSelection.Select();
    }


    public void Confirmed()
    {
        ChangeEquipSkillConfirmed();
        OpenClose();
    }
}