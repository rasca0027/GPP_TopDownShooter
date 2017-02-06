using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	
	public int health;
	public float moveSpeed;
	public GameObject missile;


	// not implemented
	public virtual void move() {}	


	// Only player bullet can damage enemy
	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "PlayerBullet") {
			health -= 1;
		}
	}
	

	// Different ways of moving

	// This one makes a zigzag diagonal movement
	protected void DiagonalMove(bool left) {

		Vector3 pos = transform.position;
		Vector3 direction;
		if (left) {
			direction = (Vector3.up + Vector3.right).normalized * moveSpeed * Time.deltaTime;
		} else {
			direction = (Vector3.up - Vector3.right).normalized * moveSpeed * Time.deltaTime;
		}
		pos -= direction;
		transform.position = pos;

	}


	// This one makes a straight line fly-in
	protected void flyIn() {
		Vector3 pos = transform.position;
		pos -= transform.up * moveSpeed * Time.deltaTime;
		transform.position = pos;
	}




	// Different ways of shooting style

	// Only shoots forward
	protected void shootForward() {
		GameObject tmp = Instantiate (missile);
		tmp.transform.position = transform.position - transform.up * 1f;
		tmp.transform.rotation = Quaternion.Euler (0, 0, -180);
		tmp.GetComponent<Rigidbody2D>().AddForce(tmp.transform.up * 400f);
		Destroy(tmp, 3);
	}


	// Shoots from two sides
	protected void shootSides() {

		GameObject left = Instantiate (missile);
		left.transform.position = transform.position - transform.right * 1f;
		left.transform.rotation = Quaternion.Euler (0, 0, 135);
		left.GetComponent<Rigidbody2D>().AddForce(left.transform.up * 400f);
		Destroy(left, 3);

		GameObject right = Instantiate (missile);
		right.transform.position = transform.position + transform.right * 1f;
		right.transform.rotation = Quaternion.Euler (0, 0, -135);
		right.GetComponent<Rigidbody2D>().AddForce(right.transform.up * 400f);
		Destroy(right, 3);

	}


	// Shoots like a circle
	protected void shootCircle() {}

}
