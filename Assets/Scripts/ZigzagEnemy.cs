using UnityEngine;
using System.Collections;

public class ZigzagEnemy : Enemy {

	private bool flag;   // flag for moving directions
	
	public override void move() {
		// override
		DiagonalMove (flag);
	}

	public ZigzagEnemy(GameObject ship) : base(ship) {
		health = 1;
		moveSpeed = 3f;
		isAlive = true;
		flag = false;
		//InvokeRepeating ("changeDirection", 0f, 2f); 
		//InvokeRepeating ("Shoot", 0f, 2f);
	}

	void Update() {
		if ((health <= 0) || (ship.transform.position.y <= -6))
			isAlive = false;
	}

	// change moving direction so it looks like zigzag
	void changeDirection() {
		flag = !flag;
	}

	void Shoot() {
		shootForward ();
	}

}
