using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	// public float rotSpeed = 180f;
	public float speed = 5f;
	public GameObject bullet;
	public float thrust = 400f;
	

	// Handles player movement
	void Update () {

		// Rotation
		/*
		Quaternion rot = transform.rotation;
		float z = rot.eulerAngles.z;
		z -= Input.GetAxis ("Horizontal") * rotSpeed * Time.deltaTime;
		rot = Quaternion.Euler (0, 0, z);
		transform.rotation = rot;
		*/

		// Movement
		Vector3 pos = transform.position;
		float x = Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
		float y = Input.GetAxis ("Vertical") * speed * Time.deltaTime;
		// pos += rot * v;
		pos += new Vector3 (x, y, 0);
		transform.position = pos;

		// Press space bar to shoot bullets
		if (Input.GetKeyDown (KeyCode.Space)) {
			Shoot();
		}



	}
	

	void Shoot() {
		GameObject obj = Instantiate(bullet);
		obj.transform.position = transform.position + transform.up * 0.5f;
		obj.GetComponent<Rigidbody2D>().AddForce(transform.up * thrust);
		Destroy(obj, 3);
	}


}
