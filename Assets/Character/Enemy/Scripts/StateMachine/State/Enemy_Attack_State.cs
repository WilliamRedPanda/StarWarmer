namespace StateMachine.Enemy
{
    public class Enemy_Attack_State : Enemy_Base_State 
    {
        public override void Enter()
        {
            base.Enter();
            context.enemy.OnStartPhaseAttack?.Invoke();
            context.enemy.ChangeStateAnimationSM("Attack", true);
        }

        public override void Tick()
        {
            base.Tick();
            context.enemy.OnPreAttack?.Invoke();
            context.enemy.OnAttack?.Invoke();
            context.enemy.OnPostAttack?.Invoke();
        }

        public override void Exit()
        {
            base.Exit();
            context.enemy.ChangeStateAnimationSM("Attack", false);
            context.enemy.ChangeStateAnimationSM("Move", false);
        }
    }
}