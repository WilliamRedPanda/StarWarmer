using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "Instance/Player")]
public class PlayerInputInstance : ScriptableObject
{
    public PlayerControllerInput instance { get; private set; }

    public void SetInstance(PlayerControllerInput testPlayer)
    {
        instance = testPlayer;
    }
}