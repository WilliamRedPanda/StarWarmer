using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillFacilityHandler : MonoBehaviour
{
    ComboFacility comboFacility;
    public ParticleSystem facilityProximityParticles;

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

    private void OnTriggerEnter(Collider other)
    {

        PlayerControllerInput player = other.GetComponentInParent<PlayerControllerInput>();

        facilityProximityParticles.Play();

    }

    private void OnTriggerExit(Collider other)
    {
        PlayerControllerInput player = other.GetComponentInParent<PlayerControllerInput>();

        facilityProximityParticles.Stop();
    }
}
