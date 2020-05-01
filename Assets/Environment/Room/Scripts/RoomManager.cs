using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RoomManager", menuName = "Data/Manager/RoomManager")]
public class RoomManager : ScriptableObject
{
    public void ActiveRoom(RoomSwitch _roomSwitch, bool _active)
    {
        _roomSwitch.gameObject.SetActive(_active);
    }
}