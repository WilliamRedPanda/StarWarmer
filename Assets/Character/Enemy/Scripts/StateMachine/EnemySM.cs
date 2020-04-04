using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine.Enemy
{
    public class EnemySM : StateMachineBase<EnemySMContext>
    {
        [SerializeField] GenericEnemy enemy;

        protected override void SetContext()
        {
            currentContext = new EnemySMContext()
            {
                enemy  = enemy,
                GoNext = GoNext,
            };
        }

        void GoNext(string _path)
        {
            SM.SetTrigger(_path);
        }
    }

    public class EnemySMContext : IStateMachineContext
    {
        public GenericEnemy enemy;

        public System.Action<string> GoNext;
    }
}