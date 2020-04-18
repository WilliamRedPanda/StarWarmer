using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboSlot : MonoBehaviour
{
    [SerializeField] SlotComboManager manager;
    [SerializeField] PlayerInputInstance player;
    [SerializeField] int slotIndex;
    [SerializeField] ComboUI comboUI;
    [SerializeField] ComboFacility comboFacility;
    [SerializeField] bool instanced = false;

    private void Start()
    {
        comboFacility = FindObjectOfType<ComboFacility>();
        if (instanced)
            comboUI.SetCombo(player.instance.playerData.sequences[slotIndex].Instance);
        if (slotIndex == 0)
            GetComponent<Button>().Select();
    }

    IEnumerator PostStart()
    {
        yield return new WaitForSeconds(0.5f);
        if (slotIndex == 0)
            GetComponent<Button>().Select();
    }
    //public void ChangeSkill()
    //{
    //    if (comboFacility.GetSelectedSkill() != null)
    //    {
    //        SetSequences set = comboFacility.GetSelectedSkill().Instance;
    //        comboUI.SetCombo(set);
    //        //player.instance.ChangeSequences(slotIndex, set.data);
    //        comboFacility.ChangeEquipSkill(slotIndex, set.data);
    //        comboFacility.ResetSelectedSkill();
    //    }
    //}

    public void SelectSlot()
    {
        manager.Select(slotIndex);
    }
}