namespace StateMachine.Enemy
{
    public class Enemy_Patrol_State : Enemy_Base_State 
    {
        public override void Enter()
        {
            base.Enter();
            context.enemy.OnStartPatrol?.Invoke();
        }

        public override void Tick()
        {
            base.Tick();
            context.enemy.PatrolTick();
        }
    }
}