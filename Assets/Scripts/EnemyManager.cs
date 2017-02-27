using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyManager : MonoBehaviour {

	public GameObject enemy1, enemy2, enemy3;
	private List<GameObject> enemies;
	private List<Enemy> enemiesClass;
	private List<Enemy> toDestroy;
    private int waveCount;
	private bool waveActive;
	private bool created;
	private List<List<string>> levelDesign;


    // Use this for initialization
	void Start () {
		enemies = new List<GameObject>();
		enemiesClass = new List<Enemy>();
		toDestroy = new List<Enemy>();
	    waveCount = 0;
		waveActive = true;
		created = false;
		levelDesign = new List<List<string>> { 
		    new List<string> {"13", "2", "2"}, 
		    new List<string> {"22", "1", "3"} 
		};
	
	        // create delegate
	        EventManager.Handler EnemyDieHandler = new EventManager.Handler(dieHandler);
	        // register handler
	        System.Type t = typeof(EnemyDieEvent);
	        EventManager.Register(t, EnemyDieHandler); 
	
	}

	void dieHandler(Event inputEvent) {
	    Debug.Log("handler called!");

	    EnemyDieEvent e = (EnemyDieEvent)inputEvent;
            foreach (Enemy enemy in enemiesClass) {
                if (enemy.ship == e.enemyObj) {
                    enemy.isAlive = false;
                }
            }

	}
	
	// Update is called once per frame
	void Update () {

		waveController();
		//Debug.Log(enemiesClass);
		//enemiesClass
		for (int i=enemiesClass.Count-1;i>=0;--i) {
			// update every enemy
			Enemy enemy = enemiesClass[i];

			if (!enemy.isAlive){
				//Debug.Log(enemy.ship);
				Debug.Log ("enemy dies");
				toDestroy.Add(enemy);
				enemiesClass.RemoveAt(i);
			} else {
				enemy.move ();
			}
		}

		// delete queue
		foreach (Enemy e in toDestroy) {
		    StopCoroutine("shooting");
		    Destroy(e.ship);
		}

	
	}

	IEnumerator createEnemy() {

		List<string> level = levelDesign[waveCount];
		for(int i=0;i<level.Count;i++) {
		// in this wave	
		    for (int j=0;j<level[i].Length;j++) {
                    // level[i] = "12"
                            GameObject instance;

                            if (level[i][j] == '1') {
                                    instance = Instantiate(enemy1);
                                    StraightEnemy tmp = new StraightEnemy(instance);
                                    StartCoroutine("shooting", tmp);
                                    enemiesClass.Add(tmp);
                            } else if (level[i][j] == '2') {
                                    instance = Instantiate(enemy2);
                                    ZigzagEnemy tmp = new ZigzagEnemy(instance);
                                    StartCoroutine("changeDirection", tmp);
                                    StartCoroutine("shooting", tmp);
                                    enemiesClass.Add(tmp);
                            } else {
                                    instance = Instantiate(enemy3);
                                    AccelarateEnemy tmp = new AccelarateEnemy(instance);
                                    StartCoroutine("shooting", tmp);
                                    enemiesClass.Add(tmp);
                            }

                            if (level[i].Length == 1) {
                                instance.transform.position = GameObject.Find ("Anchor").transform.position;
                            } else {
                                if (j == 0) 
                                    instance.transform.position = GameObject.Find ("AnchorLeft").transform.position;
                                else
                                    instance.transform.position = GameObject.Find ("AnchorRight").transform.position;
                            }
                            enemies.Add(instance);   
                    } // end for j

		    yield return new WaitForSeconds(2);
		} // end for i

		endWave();
	}

	private void waveController() {

		if (waveActive && !created) {
			// create 1 enemy every 3 secs
			StartCoroutine("createEnemy");
			created = true;
		}
	}

	private void endWave() {
		waveActive = false;
		waveCount += 1;
		created = false;
		Invoke ("startNewWave", 5f);
	}

	IEnumerator changeDirection(ZigzagEnemy tmp) {
		for (int i=0; i<=5;i++) {
			tmp.changeDirection();
			yield return new WaitForSeconds(2);
		}
	}

	private void startNewWave() {
		waveActive = true;
	}

	IEnumerator shooting(Enemy tmp) {
		for (int i=0; i<=10;i++) {
			tmp.Shoot();
			yield return new WaitForSeconds(0.8f);
		}
	}

}
