using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

	// Player's bullet will not harm myself
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag != "Player")
			Destroy (gameObject);
	}
}
