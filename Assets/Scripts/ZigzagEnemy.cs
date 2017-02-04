using UnityEngine;
using System.Collections;

public class DiagonalEnemy : Enemy {

	private bool flag;

	public DiagonalEnemy(GameObject obj) : base(obj) {
		
		// constructor
		health = 1;
		moveSpeed = 3f;
		missileType = 1;
		flag = true;
		
	}
	
	public override void move() {
		// override
		DiagonalMove (true);
	}
}
