using UnityEngine;
using System.Collections;

public class BossController : MonoBehaviour {

	BossEnemy bossClass;
	GameObject boss;

	// Use this for initialization
	void Start () {

		// create delegate
		EventManager.Handler WaveClearHandler = new EventManager.Handler(CreateBoss);
		// register
		System.Type t = typeof(WaveClearEvent);
		EventManager.Register(t, WaveClearHandler); 

	}

	void CreateBoss(Event e) {
		GameObject bossPrefab = (GameObject)Resources.Load("Boss", typeof(GameObject));
		boss = Instantiate(bossPrefab);
		bossClass = new BossEnemy(boss);
		AppearTask bossAppears = new AppearTask(bossClass);
		ShiftAndWaitTask bossWait = new ShiftAndWaitTask(bossClass);
		LargerTask bossLarger = new LargerTask(bossClass);
		
		bossAppears.Then(bossWait).Then(bossLarger);
		GetComponent<TaskManager>().AddTask(bossAppears);

		// shoot
		StartCoroutine("shooting");
	}

	public void BossHit() {
		bossClass.health -= 1;
	}

	IEnumerator shooting() {
		for (int i=0; i<=50;i++) {
			bossClass.Shoot();
			yield return new WaitForSeconds(1f);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (bossClass != null && !bossClass.isAlive)
			StopCoroutine("shooting");

	}
}
