using UnityEngine;

namespace StateMachine.Enemy
{
    public class Enemy_Rest_State : Enemy_Base_State 
    {
        float timer;

        public override void Enter()
        {
            base.Enter();
            timer = context.enemy.restTimer;
            context.enemy.OnStartRest?.Invoke();
        }

        public override void Tick()
        {
            base.Tick();
            context.enemy.RestTick();
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                context.enemy.ChangeStateLogicSM("Aggro");
            }
        }
    }
}