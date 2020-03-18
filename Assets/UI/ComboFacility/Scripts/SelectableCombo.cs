using UnityEngine;
using System.Collections;

public class SelectableCombo : MonoBehaviour
{
    [SerializeField] ComboFacility comboFacility;
    [SerializeField] SetSequencesData dataCombo;
    [SerializeField] ComboUI comboUI;

    private void Start()
    {
        comboUI.SetCombo(dataCombo.Instance);
    }

    public void SelectSkill()
    {
        comboFacility.SelectSkill(dataCombo);
        Debug.Log("SelectSkill");
    }
}