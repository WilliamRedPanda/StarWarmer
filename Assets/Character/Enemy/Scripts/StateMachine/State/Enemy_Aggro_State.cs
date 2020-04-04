namespace StateMachine.Enemy
{
    public class Enemy_Aggro_State : Enemy_Base_State 
    {
        public override void Enter()
        {
            base.Enter();
            context.enemy.OnStartAggro();
        }

        public override void Tick()
        {
            base.Tick();
            context.enemy.AggroTick();
        }
    }
}