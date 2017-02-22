using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

	// Player's bullet will not harm myself


	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag != "Player") {
		    Destroy(gameObject);
		    EnemyDieEvent newevent = new EnemyDieEvent(coll.gameObject);	
		    GameObject.Find("GameManager").GetComponent<EventManager>().NotifyEventSystem(newevent);
		    Debug.Log ("enemy killed event sent");
                }
	}
}
