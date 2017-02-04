using UnityEngine;
using System.Collections;

public class Enemy{
	
	public int health;
	public float moveSpeed;
	public int missileType;
	private GameObject enemyObj;
	private GameObject player = GameObject.Find("Player"); // fix later

	public Enemy(GameObject obj) {
		// constructor
		enemyObj = obj;
		Debug.Log ("base class constructor");
	}

	// not implemented
	public virtual void move() {}	

	// collision
	public void collide(GameObject hit) {
		if (hit.tag != "Player") {
			health -= 1;
		}
	}

	// ways of moving
	protected void DiagonalMove(bool left) {
		Vector3 pos = enemyObj.transform.position;
		Vector3 direction;
		if (left) {
			direction = (Vector3.up + Vector3.right).normalized * moveSpeed * Time.deltaTime;
		} else {
			direction = (Vector3.up - Vector3.right).normalized * moveSpeed * Time.deltaTime;
		}
		pos -= direction;
		enemyObj.transform.position = pos;
	}

	protected void flyIn() {
		Vector3 pos = enemyObj.transform.position;
		pos -= enemyObj.transform.up * moveSpeed * Time.deltaTime;
		enemyObj.transform.position = pos;
	}

	// play sounds
	protected void playSound() {}



	// shoots
	protected void shootForward() {

	}
	protected void shootSides() {}
	protected void shootCircle() {}
}
