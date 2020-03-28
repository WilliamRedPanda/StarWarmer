using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboUIInstantier : MonoBehaviour
{
    [SerializeField] PlayerInputInstance playerInstance;
    [SerializeField] Transform parentTransform;
    [Space]
    [SerializeField] ComboUI comboUIPrefab;
    [SerializeField] bool allCombo = true;
    [SerializeField][Range(0,2)] int index;

    List<ComboUI> combos;

    PlayerControllerInput player;

    bool instantied = false;
    private void Start()
    {
        if (!instantied)
        {
            player = playerInstance.instance;
            combos = new List<ComboUI>();
            if (allCombo)
            {
                foreach (var combo in player.sequences)
                {
                    InstantiateComboUI(combo);
                }
            }
            else
            {
                InstantiateComboUI(player.sequences[index]);
            }
            player.OnEndSetupSequence += ChangeCombo;
            instantied = true;
        }
    }

    void ChangeCombo()
    {
        for (int i = 0; i < combos.Count; i++)
        {
            Destroy(combos[i].gameObject);
        }

        combos = new List<ComboUI>();

        if (allCombo)
        {
            foreach (var combo in player.sequences)
            {
                InstantiateComboUI(combo);
            }
        }
        else
        {
            InstantiateComboUI(player.sequences[index]);
        }
    }

    void InstantiateComboUI(SetSequences _combo)
    {
        ComboUI combo = Instantiate(comboUIPrefab, parentTransform).GetComponent<ComboUI>();
        combo.SetCombo(_combo);
        combos.Add(combo);
    }
}