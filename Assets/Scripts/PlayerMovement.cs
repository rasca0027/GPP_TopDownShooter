using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float rotSpeed = 180f;
	public float speed = 5f;
	public GameObject bullet;
	public float thrust = 250f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		// Rotation

		Quaternion rot = transform.rotation;
		float z = rot.eulerAngles.z;
		z -= Input.GetAxis ("Horizontal") * rotSpeed * Time.deltaTime;
		rot = Quaternion.Euler (0, 0, z);
		transform.rotation = rot;
		// Movement
		Vector3 pos = transform.position;
		Vector3 v = new Vector3 (0, Input.GetAxis ("Vertical") * speed * Time.deltaTime, 0);
		pos += rot * v;
		transform.position = pos;

		if (Input.GetKeyDown (KeyCode.Space)) {
			GameObject obj = Instantiate(bullet);
			obj.transform.position = transform.position + transform.up * 0.5f;
			obj.GetComponent<Rigidbody2D>().AddForce(transform.up * thrust);

		}

	}
}
