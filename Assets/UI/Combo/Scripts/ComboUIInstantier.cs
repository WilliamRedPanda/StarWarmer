using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboUIInstantier : MonoBehaviour
{
    [SerializeField] PlayerInputInstance playerInstance;
    [SerializeField] Transform parentTransform;
    [Space]
    [SerializeField] ComboUI comboUIPrefab;

    List<ComboUI> combos;

    PlayerControllerInput player;

    private void Start()
    {
        player = playerInstance.instance;
        combos = new List<ComboUI>();
        foreach (var combo in player.sequences)
        {
            InstantiateComboUI(combo);
        }
        player.OnEndSetupSequence += ChangeCombo;
    }

    void ChangeCombo()
    {
        for (int i = 0; i < combos.Count; i++)
        {
            Destroy(combos[i].gameObject);
        }

        combos = new List<ComboUI>();

        foreach (var combo in player.sequences)
        {
            InstantiateComboUI(combo);
        }
    }

    void InstantiateComboUI(SetSequences _combo)
    {
        ComboUI combo = Instantiate(comboUIPrefab, parentTransform).GetComponent<ComboUI>();
        combo.SetCombo(_combo);
        combos.Add(combo);
    }
}