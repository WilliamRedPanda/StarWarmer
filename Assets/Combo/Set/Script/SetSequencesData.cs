using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSet", menuName = "Combo/Set")]
public class SetSequencesData : ScriptableObject
{
    //public CommandSequenceData[] comboSections;
    public CommandDataList[] combosData;
    public int startingExp;
    public float cooldown;
    public Sprite icon;
    public string comboName, description;

    public SetSequences Instance { get; private set; }

    public void SetupInstance(SetSequences _set)
    {
        Instance = _set;
    }

    private void OnDisable()
    {
        Instance = null;
    }
}

[System.Serializable]
public class CommandDataList
{
    public CommandSequenceData comboSection;
    public int NecessaryExp;
}