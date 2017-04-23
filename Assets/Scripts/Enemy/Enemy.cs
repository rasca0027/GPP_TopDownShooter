using UnityEngine;
using System.Collections;

public class Enemy {
	
	public int health;
	public float moveSpeed;
	public GameObject missile;
	public bool isAlive;
	public GameObject ship;

	public Enemy(GameObject obj) {
		ship = obj;
	}

	// not implemented
	public virtual void move() {}	

	public virtual void Shoot() {}


	// Different ways of moving

	// This one makes a zigzag diagonal movement
	protected void DiagonalMove(bool left) {

		Vector3 pos = ship.transform.position;
		Vector3 direction;
		if (left) {
			direction = (Vector3.up + Vector3.right).normalized * moveSpeed * Time.deltaTime;
		} else {
			direction = (Vector3.up - Vector3.right).normalized * moveSpeed * Time.deltaTime;
		}
		pos -= direction;
		ship.transform.position = pos;

	}


	// This one makes a straight line fly-in
	protected void flyIn() {
		Vector3 pos = ship.transform.position;
		pos -= ship.transform.up * moveSpeed * Time.deltaTime;
		ship.transform.position = pos;
	}




	// Different ways of shooting style

	// Only shoots forward
	protected void shootForward() {
		GameObject tmp = GameObject.Instantiate (missile);
		tmp.transform.position = ship.transform.position - ship.transform.up * 1f;
		tmp.transform.rotation = Quaternion.Euler (0, 0, -180);
		tmp.GetComponent<Rigidbody2D>().AddForce(tmp.transform.up * 400f);
		GameObject.Destroy(tmp, 3);
	}

	protected void BossShoot() {
		GameObject tmp = GameObject.Instantiate (missile);
		tmp.transform.position = ship.transform.position + ship.transform.up * 2f;
		tmp.transform.rotation = Quaternion.Euler (0, 0, -180);
		tmp.GetComponent<Rigidbody2D>().AddForce(tmp.transform.up * 400f);
		GameObject.Destroy(tmp, 3);
	}


	// Shoots from two sides
	protected void shootSides() {

		GameObject left = GameObject.Instantiate (missile);
		left.transform.position = ship.transform.position - ship.transform.right * 1f;
		left.transform.rotation = Quaternion.Euler (0, 0, 135);
		left.GetComponent<Rigidbody2D>().AddForce(left.transform.up * 400f);
		GameObject.Destroy(left, 3);

		GameObject right = GameObject.Instantiate (missile);
		right.transform.position = ship.transform.position + ship.transform.right * 1f;
		right.transform.rotation = Quaternion.Euler (0, 0, -135);
		right.GetComponent<Rigidbody2D>().AddForce(right.transform.up * 400f);
		GameObject.Destroy(right, 3);

	}


	// Shoots like a circle
	protected void shootCircle() {
		GameObject tmp = GameObject.Instantiate (missile);
		tmp.transform.position = ship.transform.position + ship.transform.up * 2f;
		tmp.transform.rotation = Quaternion.Euler (0, 0, -180);
		tmp.GetComponent<Rigidbody2D>().AddForce(tmp.transform.up * 400f);
		GameObject.Destroy(tmp, 3);
		GameObject tmp2 = GameObject.Instantiate (missile);
		tmp2.transform.position = ship.transform.position + ship.transform.up * 2f + ship.transform.right;
		tmp2.transform.rotation = Quaternion.Euler (0, 0, -180);
		tmp2.GetComponent<Rigidbody2D>().AddForce(tmp2.transform.up * 400f);
		GameObject.Destroy(tmp2, 3);
                GameObject tmp3 = GameObject.Instantiate (missile);
		tmp3.transform.position = ship.transform.position + ship.transform.up * 2f - ship.transform.right;
		tmp3.transform.rotation = Quaternion.Euler (0, 0, -180);
		tmp3.GetComponent<Rigidbody2D>().AddForce(tmp3.transform.up * 400f);
		GameObject.Destroy(tmp3, 3);

	
	}

}
