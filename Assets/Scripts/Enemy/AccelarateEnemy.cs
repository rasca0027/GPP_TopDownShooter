﻿using UnityEngine;
using System.Collections;

public class AccelarateEnemy : Enemy {

    public override void move() {
        flyIn();
		if ((health <= 0) || (ship.transform.position.y <= -8)) {
			isAlive = false;
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
        moveSpeed = 8f; // accelerate           
    }

    public override void Shoot() {
        shootForward();
    }

    public void Accelerate() {
        
    }

}
