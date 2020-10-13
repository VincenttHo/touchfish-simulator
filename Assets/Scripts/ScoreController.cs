using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{

    private Text text;

    public static ScoreController instance;

    private int currentScore;

    void Start()
    {
        instance = this;
        text = GetComponent<Text>();
    }

    private void Update()
    {
        text.text = currentScore + "";
    }

    public void AddScore(int score)
    {
        currentScore += score;
    }
}
