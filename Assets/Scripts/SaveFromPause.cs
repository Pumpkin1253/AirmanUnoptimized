using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System;
using System.IO;


public class SaveFromPause : MonoBehaviour
{
    public Text textScore;
    public int score;
    public string scoreStr;

    void OnMouseDown()
    {
        textScore = GameObject.Find("ScoreText").GetComponent<Text>();
        scoreStr = textScore.text;
        score = Int32.Parse(scoreStr);
        Debug.Log(scoreStr);

        saveRecordScore();
        saveCoinsAmount();
    }
    private void saveRecordScore()
    {
        int recordScore = PlayerPrefs.GetInt("recordScore");

        if (score > recordScore)
        {
            PlayerPrefs.SetInt("recordScore", score);
        }
    }
    private void saveCoinsAmount()
    {
        int coinsAmount = PlayerPrefs.GetInt("coinsAmount");

        PlayerPrefs.SetInt("coinsAmount", coinsAmount + score);
    }
}
