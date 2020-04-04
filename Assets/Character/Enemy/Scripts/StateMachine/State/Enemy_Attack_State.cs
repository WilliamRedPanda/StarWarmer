namespace StateMachine.Enemy
{
    public class Enemy_Attack_State : Enemy_Base_State 
    {
        public override void Tick()
        {
            base.Tick();
            context.enemy.OnPreAttack?.Invoke();
            context.enemy.OnAttack?.Invoke();
            context.enemy.OnPostAttack?.Invoke();
        }
    }
}