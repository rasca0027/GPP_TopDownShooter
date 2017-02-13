using UnityEngine;
using System.Collections;

public class StraightEnemy : Enemy {
	

	public override void move() {
		// override
		flyIn ();
	}

	public StraightEnemy(GameObject ship):base(ship) {
		health = 20;
		moveSpeed = 3f;
		isAlive = true;
		//InvokeRepeating ("Shoot", 0f, 0.6f);

	}

	void Update () {
		if ((health <= 0) || (ship.transform.position.y <= -8))
			isAlive = false;
	}

	void Shoot() {
		shootSides ();
	}

}
