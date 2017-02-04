using UnityEngine;
using System.Collections;

public class StraightEnemy : Enemy {

	public StraightEnemy() : base() {

		// constructor
	}

	public override void move() {
		// override
		flyIn ();

	}

	void Start() {
		health = 2;
		moveSpeed = 3f;
		missileType = 1;
		InvokeRepeating ("Shoot", 0f, 0.6f);

	}

	void Update () {
		if (health <= 0)
			Destroy (gameObject);
		move ();

	}

	void Shoot() {
		shootSides ();
	}

}
