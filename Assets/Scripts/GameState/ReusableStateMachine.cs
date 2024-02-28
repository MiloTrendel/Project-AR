using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class BaseState<EState> where EState : Enum
{
    public BaseState(EState key)
    {
        StateKey = key;
    }

    public EState StateKey { get; private set; }

    public abstract void EnterState();
    public abstract void ExitState();
    public abstract void UpdateState();
    public abstract EState GetNextState();
    public void OnTriggerEnter(Collider other) {}
    public void OnTriggerStay(Collider other) {}
    public void OnTriggerExit(Collider other) {}
}

public abstract class StateManager<EState> : MonoBehaviour where EState : Enum
{
    protected Dictionary<EState, BaseState<EState>> States = new();

    protected BaseState<EState> CurrentState;

    protected bool IsTransitioningState = false;

    public virtual void Start()
    {
        CurrentState.EnterState();
    }

    public virtual void Update()
    {
        EState NextStateKey = CurrentState.GetNextState();

        if (!IsTransitioningState && NextStateKey.Equals(CurrentState.StateKey))
        {
            CurrentState.UpdateState();
        }
        else if (!IsTransitioningState)
        {
            TransitionToState(NextStateKey);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        CurrentState.OnTriggerEnter(other);
    }

    private void OnTriggerStay(Collider other)
    {
        CurrentState.OnTriggerStay(other);
    }

    private void OnTriggerExit(Collider other)
    {
        CurrentState.OnTriggerExit(other);
    }

    private void TransitionToState(EState NextStateKey)
    {
        IsTransitioningState = true;
        CurrentState.ExitState();
        CurrentState = States[NextStateKey];
        CurrentState.EnterState();
        IsTransitioningState = false;
    }
}