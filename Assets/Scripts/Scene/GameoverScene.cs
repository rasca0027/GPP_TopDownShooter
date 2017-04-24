using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameoverScene : Scene<TransitionData> {

    internal override void OnEnter(TransitionData data) {
        int score = Service.score;
        GameObject.Find("Canvas/Root/GameoverScene/ScoreText").GetComponent<Text>().text = "Your score: " + score.ToString();

        // score board
        ScoreBoard scores = Resources.Load<ScoreBoard>("ScoreBoard"); 
        if (score >= scores.Scores[0]) {
            scores.Scores[0] = score;
        }

        GameObject.Find("Canvas/Root/GameoverScene/HighScoreText").GetComponent<Text>().text = "High score: " + scores.Scores[0].ToString();

    }

    internal override void OnExit() {
        // set menu deactive   
    }

}
