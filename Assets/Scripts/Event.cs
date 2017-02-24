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


