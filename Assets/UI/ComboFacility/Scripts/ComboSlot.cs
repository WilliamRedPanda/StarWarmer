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
    public Image imageHighlight;

    Button button;

    private void OnEnable()
    {
        button = GetComponent<Button>();

        comboFacility = FindObjectOfType<ComboFacility>();
        if (instanced)
            comboUI.SetCombo(player.instance.playerData.sequences[slotIndex].Instance);
        if (slotIndex == 0)
            button.Select();
    }

    //private void Start()
    //{
    //    comboFacility = FindObjectOfType<ComboFacility>();
    //    if (instanced)
    //        comboUI.SetCombo(player.instance.playerData.sequences[slotIndex].Instance);
    //    if (slotIndex == 0)
    //        GetComponent<Button>().Select();
    //}

    void Start()
    {
        //yield return new WaitForSeconds(0.22f);
        if (slotIndex == 0)
        {
            button.Select();
            imageHighlight.enabled = true;
            button.Select();
        }
    }

    public void ChangeSkill(SetSequences set)
    {
        comboUI.SetCombo(set);
    }

    public void Highlight()
    {
        imageHighlight.enabled = true;
        button.Select();
    }

    public void SelectSlot()
    {
        Debug.Log("pressed Slot");
        manager.Select(slotIndex);
    }
}