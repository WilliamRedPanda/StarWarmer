using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillFacilityHandler : MonoBehaviour
{
    ComboFacility comboFacility;

    private void OnTriggerStay(Collider other)
    {
        PlayerControllerInput player = other.GetComponentInParent<PlayerControllerInput>();

        if (player)
        {
            if (comboFacility == null)
                comboFacility = player.comboFacility;

            if (comboFacility)
            {
                comboFacility.HandleInput();
            }
        }
    }
}
