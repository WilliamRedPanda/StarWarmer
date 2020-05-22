using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class AddExpDebug : MonoBehaviour
{
    [SerializeField] PlayerControllerInput player;
    [SerializeField] Key keyButton;
    [SerializeField] Key altKeyButton;
    [SerializeField] int expToAdd;
    [SerializeField] bool allSkill;
    [SerializeField]
    [Range(1, 3)]
    [Tooltip("se allSkill è false la skill che aumenta di livello è quella equipaggiata nello slot numero: slot")]
    int slot = 1;

    void Update()
    {
        if (Keyboard.current != null)
        {
            if(Keyboard.current[keyButton].wasPressedThisFrame || Keyboard.current[altKeyButton].wasPressedThisFrame)
            {
                if (allSkill)
                {
                    for (int i = 0; i < player.sequences.Count; i++)
                    {
                        player.sequences[i].AddExp(expToAdd);
                    }
                }
                else
                {
                    player.sequences[slot].AddExp(expToAdd);
                }
            }
        }
    }
}