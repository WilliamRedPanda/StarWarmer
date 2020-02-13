using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public static class RoomManager
{
    static CinemachineVirtualCameraBase currentVirtualCamera;

    public static void ChangeCamera(CinemachineVirtualCameraBase _virtualCamera)
    {
        _virtualCamera.gameObject.SetActive(true);
        if (currentVirtualCamera)
        {
            currentVirtualCamera.gameObject.SetActive(false);
            Debug.Log(currentVirtualCamera.name + currentVirtualCamera.gameObject.activeInHierarchy + " " + currentVirtualCamera.name);
        }
        currentVirtualCamera = _virtualCamera;
        Debug.Log(_virtualCamera.name + _virtualCamera.gameObject.activeInHierarchy + " " + currentVirtualCamera.name);
    }
}