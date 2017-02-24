using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class EventManager : MonoBehaviour {

    public delegate void Handler(Event e);
    
    private static Dictionary<System.Type, Handler> handlerTable = new Dictionary<System.Type, Handler>();
    
    public static void Register(System.Type type, Handler handler) {


        if (handlerTable.ContainsKey(type)) {
            handlerTable[type] += handler;
        } else {
            handlerTable[type] = handler;
        }
    
    }

    public static void Unregister(System.Type type, Handler handler) {
        
        if (handlerTable.ContainsKey(type)) {
            // remove from dictionary 
            handlerTable[type] -= handler;
            if (handlerTable[type] == null)
                handlerTable.Remove(type);
        }
    
    }

    public void NotifyEventSystem(Event e) {

	System.Type t = e.GetType();
        Debug.Log("Notified, " + t);

        // when someone notifys EventSystem that something happens
	Handler handlers;
	if (handlerTable.TryGetValue(t, out handlers)) {
	    handlers(e);
	}
        

    }
    

}
