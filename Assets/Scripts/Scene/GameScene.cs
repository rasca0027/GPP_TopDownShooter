using UnityEngine;
using System.Collections;

public class GameScene : Scene<TransitionData> {


    internal override void OnEnter(TransitionData data) {

        // set enemy active
        GameStartEvent e = new GameStartEvent();
        GameObject.Find("GameManager").GetComponent<EventManager>().NotifyEventSystem(e);
    }

    internal override void OnExit() {
        // set menu deactive   
    }
}
