using UnityEngine;
using System.Collections;

public class BossController : MonoBehaviour {


	// Use this for initialization
	void Start () {
            AppearTask bossAppears = new AppearTask();
            ShiftAndWaitTask bossWait = new ShiftAndWaitTask();
            LargerTask bossLarger = new LargerTask();

            bossAppears.Then(bossWait).Then(bossLarger);
            GetComponent<TaskManager>().AddTask(bossAppears);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
