
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine
{
    [RequireComponent(typeof(Animator))]
    public abstract class StateMachineBase<T> : MonoBehaviour
    {
        protected Animator SM;

        protected T currentContext;

        protected virtual void Awake()
        {
            SM = GetComponent<Animator>();
        }

        protected virtual void Start()
        {
            SetContext();
            foreach (StateMachineBehaviour smB in SM.GetBehaviours<StateMachineBehaviour>())
            {
                (smB as StateBase<T>).Setup(currentContext);
            }
        }

        protected abstract void SetContext();
    }
}