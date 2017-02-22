using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

	// Player's bullet will not harm myself


	void OnTriggerEnter2D(Collider2D coll) {
		Debug.Log("triiger somethign");
		if (coll.gameObject.tag != "Player")
			Destroy (coll.gameObject);
	}
}
