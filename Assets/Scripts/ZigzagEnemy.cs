using UnityEngine;
using System.Collections;

public class ZigzagEnemy : Enemy {

	private bool flag = false;   // flag for moving directions
	
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
		missile = (GameObject)Resources.Load("Missile2", typeof(GameObject));
	}

	void Update() {
		if ((health <= 0) || (ship.transform.position.y <= -6))
			isAlive = false;
	}

	public void changeDirection() {	
		Debug.Log("change Direction");
		flag = !flag;
	}

	public override void Shoot() {
		shootForward ();
	}

}
