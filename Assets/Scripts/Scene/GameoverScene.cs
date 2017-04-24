using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameoverScene : Scene<TransitionData> {

    internal override void OnEnter(TransitionData data) {
        int score = GameObject.Find("Player").GetComponent<PlayerHealth>().score;
        GameObject.Find("Canvas/Root/GameoverPanel/ScoreText").GetComponent<Text>().text = score.ToString();
    }

    internal override void OnExit() {
        // set menu deactive   
    }

}
