using StateMachine;
using StateMachine.Gameplay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gameplay_Win_State : Gameplay_Base_State
{
    [SerializeField] GameObject winUIPrefab;

    GameObject winUI;
    public override void Enter()
    {
        base.Enter();
        winUI = Instantiate(winUIPrefab);
    }

    public override void Exit()
    {
        base.Exit();
        if (winUI)
            Destroy(winUI);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}