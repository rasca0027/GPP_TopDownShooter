﻿using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

    // Player's bullet will not harm myself
    float preTime = 0f;

    void OnTriggerEnter2D(Collider2D coll) {

        if (coll.gameObject.tag != "Player") {
            if (coll.gameObject.tag == "Boss") {
                Destroy(gameObject);	
                GameObject.Find("GameManager").GetComponent<BossController>().BossHit();
            } else {

                if (coll.gameObject.tag == "straight") {
                    StraightEnemyEvent e = new StraightEnemyEvent(coll.gameObject);    
                    GameObject.Find("GameManager").GetComponent<EventManager>().NotifyEventSystem(e);
                }

                // Normal enemy
                Destroy(gameObject);
                EnemyDieEvent newevent = new EnemyDieEvent(coll.gameObject);	
                GameObject.Find("GameManager").GetComponent<EventManager>().NotifyEventSystem(newevent);

                if (Time.time - preTime <= 3f) {
                    // send event
                    TwoShotEvent eve = new TwoShotEvent();
                    Debug.Log("two shots");
                    GameObject.Find("GameManager").GetComponent<EventManager>().NotifyEventSystem(eve);
                }
                preTime = Time.time;
            }
        } 
    }


}

