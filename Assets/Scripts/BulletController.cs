﻿using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag != "Player")
			Destroy (gameObject);
	}
}
