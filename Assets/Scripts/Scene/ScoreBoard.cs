using UnityEngine;

[CreateAssetMenu (menuName = "ScoreBoard")]
public class ScoreBoard : ScriptableObject {

    [SerializeField] private int[] _scores;
    public int[] Scores
    {
        get { return _scores; }
    }

}
