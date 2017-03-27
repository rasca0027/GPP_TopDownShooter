using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public int health = 20;
	public int score = 0;
	private SpriteRenderer sp;
	private bool bonus = false;

	// Use this for initialization
	void Start () {
		sp = GetComponent<SpriteRenderer>();
		// register handler
        	EventManager.Handler ScoreHandler = new EventManager.Handler(handler);
        	System.Type t = typeof(EnemyDieEvent);
        	EventManager.Register(t, ScoreHandler);
	
	}

        public void handler(Event inputEvent) {
        	// add score
		if (!bonus)
			score += 10;
		else
			score += 20;           
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

	public void SetBonus(bool state) {
		bonus = state;
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
