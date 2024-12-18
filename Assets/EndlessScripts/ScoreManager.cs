using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int Score = 0;

    public Text ScoreText;

    public void Start()
    {
        StartCoroutine(IncreaseScoreOverTime());
    }
    
    IEnumerator IncreaseScoreOverTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            Score += 1;
            UpdateScoreUi();
        }

    }

    void UpdateScoreUi()
    {
        ScoreText.text = "Score: " + Score;
    }

}
