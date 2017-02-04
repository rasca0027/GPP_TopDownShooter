using UnityEngine;
using System.Collections;

public class StraightEnemy : Enemy {

	public StraightEnemy(GameObject obj) : base(obj) {

		// constructor
		health = 2;
		moveSpeed = 3f;
		missileType = 1;

	}

	public override void move() {
		// override
		flyIn ();

	}
}
