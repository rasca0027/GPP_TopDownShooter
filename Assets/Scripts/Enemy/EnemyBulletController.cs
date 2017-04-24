using UnityEngine;
using System.Collections;

public class EnemyBulletController : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D coll) {
            if (coll.gameObject.tag == "Player") {
                GameObject.Find ("Player").GetComponent<PlayerHealth>().DamagePlayer();
                Destroy(gameObject);
            } else if (coll.gameObject.tag == "Companion") {
                Debug.Log("Hit companion");
                GameObject.Find ("Guard").GetComponent<Companion>().damageCompanion();
                Destroy(gameObject);
            }

	}
}
