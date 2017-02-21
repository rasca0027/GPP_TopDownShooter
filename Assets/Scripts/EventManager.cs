using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Event {    

}

public class EnemyDieEvent : Event {

    public GameObject enemy;

    public EnemyDieEvent(GameObject diedEnemy) {
        enemy = diedEnemy;
    }

}



public class EventManager : MonoBehaviour {

    public delegate void Handler(Event e);
    
    private Dictionary<System.Type, Handler> handlerTable = new Dictionary<System.Type, Handler>();
    
    public void Register(System.Type type, Handler handler) {
        
        if (handlerTable.ContainsKey(type)) {
            handlerTable[type] += handler;
        } else {
            handlerTable[type] = handler;
        }
    
    }

    public void Unregister(System.Type type, Handler handler) {
        
        if (handlerTable.ContainsKey(type)) {
            // remove from dictionary 
            handlerTable[type] -= handler;
            if (handlerTable[type] == null)
                handlerTable.Remove(type);
        }
    
    }

    public void NotifyEventSystem(Event e) {

        //System.Type t = typeof(e);
		System.Type t = e.GetType();
        // when someone notifys EventSystem that something happens
		/*
        foreach (Handler h in handlerTable[t]) {
            h(e);
        }
        */
		Debug.Log ("notified");

    }
    

}
