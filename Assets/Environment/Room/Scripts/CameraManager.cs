using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public static class CameraManager
{
    static RoomSwitch currentRoom;

    public static void ChangeCamera(RoomSwitch _room)
    {
        if (currentRoom)
            if (currentRoom == _room)
                return;

        _room.cameraShake.virtualCamera.gameObject.SetActive(true);
        if (currentRoom)
        {
            currentRoom.cameraShake.virtualCamera.gameObject.SetActive(false);
        }
        currentRoom = _room;
    }
}