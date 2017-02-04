using UnityEngine;
using System.Collections;

public class EnemyController2 : MonoBehaviour {
	
	public DiagonalEnemy ship;

	
	// Use this for initialization
	void Start () {
		ship = new DiagonalEnemy (gameObject);

	}
	
	// Update is called once per frame
	void Update () {

		if (ship.health <= 0)
			Destroy (gameObject);
		ship.move ();

	}
	
	void OnCollisionEnter2D(Collision2D coll) {
		ship.collide (coll.gameObject);
	}


}


