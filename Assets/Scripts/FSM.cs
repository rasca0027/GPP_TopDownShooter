using UnityEngine;
using System.Collections;

public class FSM : MonoBehaviour {

    // We keep track of the state machine's current state and expose it through a public
    // property in case someone needs to query it.
    public State CurrentState { get; private set; }

    // We don't want to change the current state in the middle of an update, so when a transition is called
    private State _pendingState;

    void Start() 
    {
        TransitionTo(new NormalState());
    }

    public void Update()
    {
        // Handle any pending transition if someone called TransitionTo externally (although they probably shouldn't) 
        PerformPendingTransition();
        // Make sure there's always a current state to update...
        Debug.Assert(CurrentState != null, "No Current State!");
        CurrentState.Update();
        // Handle any pending transition that might have happened during the update
        PerformPendingTransition();
    }

    // Queues transition to a new state
    public void TransitionTo(State TState)
    {
        // We do the actual transtion 
        _pendingState = TState;
    }

    // Actually transition to any pending state
    private void PerformPendingTransition()
    {
        if (_pendingState != null)
        {
            if (CurrentState != null) CurrentState.OnExit();
            CurrentState = _pendingState;
            CurrentState.OnEnter();
            _pendingState = null;
        }
    }


}
