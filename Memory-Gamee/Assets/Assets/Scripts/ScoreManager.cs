using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public int timeForLevelToComplete = 60;
    public Image timeImage;

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
            // fill anount (0,1) so we use /
        }
        // Game Over
        GameManager.instance.GameOver();
    }
}
