using UnityEngine;
using System.Collections;

public class EnemyHit : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            GameObject.Find("Player").GetComponent<PlayerHealth>().DamagePlayer();
        }
    }

}
