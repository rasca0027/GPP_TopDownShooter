using UnityEngine;
using System.Collections;

public class StraightEnemy : Enemy {
	

	public override void move() {
		// override
		flyIn ();
	}

	void Start() {
		health = 2;
		moveSpeed = 3f;
		InvokeRepeating ("Shoot", 0f, 0.6f);

	}

	void Update () {
		if ((health <= 0) || (transform.position.y <= -6))
			Destroy (gameObject);
		move ();
	}

	void Shoot() {
		shootSides ();
	}

}
