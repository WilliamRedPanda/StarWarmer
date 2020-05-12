using StateMachine;
using StateMachine.Gameplay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gameplay_Lose_State : Gameplay_Base_State
{
    [SerializeField] GameObject loseUIPrefab;

    GameObject loseUI;
    public override void Enter()
    {
        base.Enter();
        context.playerController.ResetVelocity();
        loseUI = Instantiate(loseUIPrefab);
    }

    public override void Tick()
    {
        base.Tick();
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            context.Exit("Gameplay");
        }
    }

    public override void Exit()
    {
        base.Exit();
        if (loseUI)
            Destroy(loseUI);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}