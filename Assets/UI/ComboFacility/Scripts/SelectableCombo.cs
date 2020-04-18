using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SelectableCombo : MonoBehaviour
{
    [SerializeField] ComboFacility comboFacility;
    [SerializeField] SetSequencesData dataCombo;
    [SerializeField] ComboUI comboUI;

    [HideInInspector] public Button button;

    private void Start()
    {
        comboUI.SetCombo(dataCombo.Instance);
        button = GetComponent<Button>();
    }

    //public void SelectSkill()
    //{
    //    comboFacility.SelectSkill(dataCombo);
    //}

    public void ChangeCurrentView()
    {
        comboFacility.ChangeCurrentSkillView(dataCombo);
    }

    public void ChangeSkill()
    {
        SetSequences set = comboUI.combo;
        //player.instance.ChangeSequences(slotIndex, set.data);
        comboFacility.ChangeEquipSkill(comboFacility.currentSlot, set.data);
        comboFacility.ResetSelectedSkill();
    }
}