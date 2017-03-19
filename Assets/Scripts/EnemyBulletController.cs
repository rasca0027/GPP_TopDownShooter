using UnityEngine;
using System.Collections;

public class EnemyBulletController : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Player") {
			//Debug.Log("Enemy Bullet hit player");
			GameObject.Find ("Player").GetComponent<PlayerHealth>().DamagePlayer();
			Destroy(gameObject);
		}
	}
}
