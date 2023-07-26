using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    public int timeForLevelToComplete = 60;
    public Image timeImage;

    public TMP_Text timeText;

    void Start()
    {

        StartCoroutine("Timer");

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
}
