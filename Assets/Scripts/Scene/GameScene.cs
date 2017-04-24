using UnityEngine;
using System.Collections;

public class GameScene : Scene<TransitionData> {


    internal override void OnEnter(TransitionData data) {

        // set enemy active
        GameStartEvent e = new GameStartEvent();
        GameObject.Find("GameManager").GetComponent<EventManager>().NotifyEventSystem(e);
 
	// create delegate	
	EventManager.Handler GameoverHandler = new EventManager.Handler(overHandler);
	// register handler
	System.Type t = typeof(GameoverEvent);
	EventManager.Register(t, GameoverHandler); 
	
	// upgrade effects
	if (data.upgrade != null) {
	    data.upgrade.Effect();
	    Debug.Log("effects!");
	}
    }

    void overHandler(Event inputEvent) {
	Service.Scenes.PushScene<GameoverScene>(new TransitionData());	
    }

    internal override void OnExit() {
        // set menu deactive   
    }
}
