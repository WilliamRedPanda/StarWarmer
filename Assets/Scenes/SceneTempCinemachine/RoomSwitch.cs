using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(BoxCollider))]
public class RoomSwitch : MonoBehaviour
{
    [SerializeField] CameraShake cameraShake;

    private void OnTriggerEnter(Collider collision)
    {
        PlayerData player = collision.gameObject.GetComponentInParent<PlayerData>();
        if (player)
        {
            cameraShake.SetPlayer(player);
            RoomManager.ChangeCamera(cameraShake.virtualCamera);
        }
    }
}