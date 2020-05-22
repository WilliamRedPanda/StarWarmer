using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
using UnityEngine.SceneManagement;

public class CheckDeviceInput : MonoBehaviour
{
    public static CheckDeviceInput instance;
    [SerializeField] CurrentControllerManager controllerManager;
    [SerializeField] PlayerInput playerInput;

    InputSystemUIInputModule uiInpuSystem;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }

        SceneManager.sceneLoaded += OnLoadScene;
    }

    private void OnLoadScene(Scene arg0, LoadSceneMode arg1)
    {
        uiInpuSystem = FindObjectOfType<InputSystemUIInputModule>();

        if (playerInput && uiInpuSystem)
        {
            playerInput.uiInputModule = uiInpuSystem;
        }
    }

    private void Update()
    {
        controllerManager.CheckChangeCurrentDevice();
    }
}