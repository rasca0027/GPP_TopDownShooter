using UnityEngine;
using System.Collections;

public class FSMScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
            Service.fsm.TransitionTo(new NormalState());
	}
	
	// Update is called once per frame
	void Update () {
            Service.fsm.Update();	
	}
}
