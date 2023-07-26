using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager instance;

    public int timeForLevelToComplete = 60;
    public Image timeImage;

    public TMP_Text timeText;
    public TMP_Text scoreText;


    int score;

    void Awake()
    {
        instance = this;
    }
    void Start()
    {

        StartCoroutine("Timer");
        AddScore(0);
    }


    IEnumerator Timer()
    {
        int tempTime = timeForLevelToComplete;
        while (tempTime > 0)
        {
            tempTime--; // current time
            yield return new WaitForSeconds(1);

            timeImage.fillAmount = tempTime / (float)timeForLevelToComplete; // currentTime/maxTime
            // fill anount (0,1) so we use slash /
            timeText.text = tempTime.ToString();
        }
        // Game Over
        GameManager.instance.GameOver();
    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = score.ToString("D8"); // number has 8 decimal length
    }
}
