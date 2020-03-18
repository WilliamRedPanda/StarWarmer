using UnityEngine;
using System.Collections;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] RoomSwitch room;
    [SerializeField] DoorDirection doorDirection;

    private void OnTriggerEnter(Collider other)
    {
        if (room.roomFinished)
        {
            PlayerData player = other.GetComponentInParent<PlayerData>();
            if (player)
            {
                room.ChangeRoom(player, doorDirection);
            }
        }
    }

    public enum DoorDirection
    {
        north, south, west, east,
    }
}