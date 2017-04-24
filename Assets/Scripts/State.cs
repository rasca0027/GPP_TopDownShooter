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

    System.Type t;
    EventManager.Handler TwoShotHandler;
    
    public override void OnEnter() {
        // register
        t = typeof(TwoShotEvent);
        TwoShotHandler = new EventManager.Handler(h);
        EventManager.Register(t, TwoShotHandler);
    
    }
    
    public void h(Event inputEvent) {
        TransitionTo(new BonusState());
    }

    public override void Update() {
        // if health too low go to lowHealthState
        int health = GameObject.Find("Player").GetComponent<PlayerHealth>().health;
        if (health <= 3)
            TransitionTo(new LowHealthState());
        // if hit 2 enemy in a row go to bonus state
        
    }

    public override void OnExit() {
        EventManager.Unregister(t, TwoShotHandler);
    }

}

public class BonusState : State {

    float timer = 0;
    float timeToWait = 5f;
    Color defaultColor;
    float duration = 3f;

    public override void OnEnter() {
        GameObject.Find("Player").GetComponent<PlayerHealth>().SetBonus(true);
        defaultColor = Camera.main.backgroundColor;
        float t = Mathf.PingPong(Time.time, duration) / duration;
        Camera.main.backgroundColor = Color.Lerp(Color.red, Color.blue, t);
    }

   
    public override void Update() {
        // change background or add effects   
        // twice score
        // after 5 seconds go back to normal state
        timer += Time.deltaTime;
        if (timer >= timeToWait) {
            TransitionTo(new NormalState());
        }
    }

    public override void OnExit() {
        GameObject.Find("Player").GetComponent<PlayerHealth>().SetBonus(false);
        Camera.main.backgroundColor = defaultColor;
    }

}

public class LowHealthState : State {
    
    Color c = new Color(0.7f, 0.3f, 0.2f);
    Color defaultColor;

    public override void OnEnter() {
        Debug.Log("in low health state!");
        defaultColor = Camera.main.backgroundColor;
        Camera.main.backgroundColor = c;

    }

    public override void Update() {
        // put a heart beating?

        // if die go back to normal state
        GameObject player = GameObject.Find("Player");
        if (!player) {
            TransitionTo(new GameOverState());
        }
        
    }

    public override void OnExit() {
       Camera.main.backgroundColor = defaultColor;
    }

}

public class GameOverState : State {
    
    public override void OnEnter() {
        Debug.Log("in game over state!");
        Camera.main.backgroundColor = Color.white;
        GameoverEvent e = new GameoverEvent();
        GameObject.Find("GameManager").GetComponent<EventManager>().NotifyEventSystem(e);
    }

    public override void Update() {

        
    }


}
