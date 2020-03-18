using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboSlot : MonoBehaviour
{
    //static int n = 0;

    [SerializeField] PlayerInputInstance player;
    [SerializeField] int slotIndex;
    [SerializeField] ComboUI comboUI;
    [SerializeField] ComboFacility comboFacility;
    [SerializeField] bool instanced = false;

    //private void Awake()
    //{
    //    slotIndex = n;
    //    n++;
    //}

    //private void OnDisable()
    //{
    //    n--;
    //}

    private void Start()
    {
        comboFacility = FindObjectOfType<ComboFacility>();
        if (instanced)
            comboUI.SetCombo(player.instance.playerData.sequences[slotIndex].Instance);
    }

    public void ChangeSkill()
    {
        if (comboFacility.GetSelectedSkill() != null)
        {
            SetSequences set = comboFacility.GetSelectedSkill().Instance;
            comboUI.SetCombo(set);
            //player.instance.ChangeSequences(slotIndex, set.data);
            comboFacility.ChangeEquipSkill(slotIndex, set.data);
            comboFacility.ResetSelectedSkill();
        }
    }
}