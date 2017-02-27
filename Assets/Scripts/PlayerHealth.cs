using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public int health = 4;
	SpriteRenderer sp;

	// Use this for initialization
	void Start () {
		sp = GetComponent<SpriteRenderer>();


	}
	
	// Update is called once per frame
	void Update () {
		// check life
		if (health <= 0) {
			// die
			StartCoroutine(Flash(0.3f, 3));
		}
	}

	public void DamagePlayer() {
		health -= 1;
		OnHealthDecrease();
	}

	void OnCollisionEnter2D(Collision2D coll) {
		// Enemy or enemybullets hit
		health -= 1;
		OnHealthDecrease();
	}

	void OnHealthDecrease() {
		StartCoroutine(Flash(0.3f, 1));
	}

	
	IEnumerator Flash(float x, int times) {
		
		for (int i = 0; i < times; i++) {
			sp.enabled = false;
			yield return new WaitForSeconds(x);
			sp.enabled = true;
			yield return new WaitForSeconds(x);
		}
		if (times == 3)
			die ();
	}

	void die() {
		Debug.Log ("Player die");
		Destroy (gameObject, 0.5f);
	}
}
