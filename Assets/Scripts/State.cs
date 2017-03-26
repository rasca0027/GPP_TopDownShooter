using UnityEngine;
using System.Collections;

public abstract class State {

    // A convenience method for transitioning from inside a state
    protected void TransitionTo(State TState)
    {
	Service.fsm.TransitionTo(TState);
    }
    // I don't need Init because I did not use cache
    // This is called whenever the state becomes active (think of it like Unity's Start)
    public virtual void OnEnter() { }

    // this is called whenever the state becomes inactive
    public virtual void OnExit() { }

    // This is your standard update method where most of your work should go
    public virtual void Update() { }

    // called when the state machine is cleared, and where you should clear resources
    public virtual void CleanUp() { }

}

public class NormalState : State {

    public override void OnEnter() {
        Debug.Log("in normal state!");
    }

    public override void Update() {
        // if health too low go to lowHealthState
        int health = GameObject.Find("Player").GetComponent<PlayerHealth>().health;
        if (health <= 3)
            TransitionTo(new LowHealthState());
        // if hit 2 enemy in a row go to bonus state
        
    }


}

public class BonusState : State {

    public override void OnEnter() {
        Debug.Log("in bonus state!");
    }

    public override void Update() {
        // change background or add effects
        // twice score
        // after 5 seconds go back to normal state
    }

}

public class LowHealthState : State {

    public override void OnEnter() {
        Debug.Log("in low health state!");
    }

    public override void Update() {
        // put a heart beating?

        // if die go back to normal state
    }

}
