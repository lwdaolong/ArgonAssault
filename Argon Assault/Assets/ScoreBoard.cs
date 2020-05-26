using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    int score;
    Text scoreText;

    [SerializeField] int defaultScore = 12;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        scoreText.text = score.ToString();
    }

    public void addScore()
    {
        score += defaultScore;
        scoreText.text = score.ToString();
    }

    public void addScore(int specialScore)
    {
        score += specialScore;
        scoreText.text = score.ToString();
    }

}
