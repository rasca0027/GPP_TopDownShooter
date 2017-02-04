using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	StraightEnemy alien;

	// Use this for initialization
	void Start () {
		alien = new StraightEnemy (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		if (alien.health <= 0)
			Destroy (gameObject);
		alien.move ();
	}

	void OnCollisionEnter2D(Collision2D coll) {
		alien.collide (coll.gameObject);
	}
	
}


