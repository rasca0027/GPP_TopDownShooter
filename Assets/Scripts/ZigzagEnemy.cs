using UnityEngine;
using System.Collections;

public class ZigzagEnemy : Enemy {

	private bool flag;   // flag for moving directions


	public override void move() {
		// override
		DiagonalMove (flag);
	}

	void Start() {
		health = 1;
		moveSpeed = 3f;
		flag = false;
		InvokeRepeating ("changeDirection", 0f, 2f); 
		InvokeRepeating ("Shoot", 0f, 1f);
	}

	void Update() {
		if (health <= 0)
			Destroy (gameObject);
		move ();
	}

	// change moving direction so it looks like zigzag
	void changeDirection() {
		flag = !flag;
	}

	void Shoot() {
		shootForward ();
	}

}
