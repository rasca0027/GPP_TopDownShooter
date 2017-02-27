using UnityEngine;
using System.Collections;

public class AccelarateEnemy : Enemy {

    public override void move() {
        flyIn();
        if (health <= 0) {
           Debug.Log("I'm dead trigger sometihng.....");
        }
    }

    public AccelarateEnemy(GameObject ship) : base(ship) {
        health = 1;
        moveSpeed = 2f;
        isAlive = true;
	missile = (GameObject)Resources.Load("Missile2", typeof(GameObject));
        
        
        // get eventSystem and register for handler

        // register handler
        EventManager.Handler StraightDieHandler = new EventManager.Handler(handler);
        System.Type t = typeof(StraightEnemyEvent);
        EventManager.Register(t, StraightDieHandler);
    }

    public void handler(Event inputEvent) {
        Debug.Log("Hanlder called, Accelerate");
        moveSpeed = 8f; // accelerate           
    }

    public override void Shoot() {
        shootForward();
    }

    public void Accelerate() {
        
    }

}
