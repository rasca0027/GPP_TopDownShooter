using UnityEngine;
using System.Collections;

public class BossEnemy : Enemy {
	
        public bool isPhase3;    

	public override void move() {
		// override
		if (health <= 0) {
			isAlive = false;
		}
	}
	
	public BossEnemy(GameObject ship):base(ship) {
		health = 8;
		moveSpeed = 2f;
		isAlive = true;
		missile = (GameObject)Resources.Load("Missile1", typeof(GameObject));
	        isPhase3 = false;	
	}
	
	public override void Shoot() {
	    if (!isPhase3) 	
	        BossShoot();
	    else	
	        shootCircle();
	}
	
}
