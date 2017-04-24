using UnityEngine;
using System.Collections;


public abstract class Event {    

}

public class EnemyDieEvent : Event {

    public GameObject enemyObj;

    public EnemyDieEvent(GameObject diedEnemy) {
        enemyObj = diedEnemy;
    }

}

public class StraightEnemyEvent : Event {

    public GameObject enemyObj;

    public StraightEnemyEvent(GameObject diedEnemy) {
        enemyObj = diedEnemy;
    }

}

public class WaveClearEvent : Event {
	
	public GameObject enemyObj;
	
	public WaveClearEvent() {

	}
	
}

public class TwoShotEvent : Event {

    

}

public class GameStartEvent : Event {
    public GameStartEvent() {
    
    }

}

public class GameoverEvent : Event {
    public GameoverEvent() {
    
    }

}
