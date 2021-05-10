using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    public int score;

    public int TotalScore;


    public int scoreForWin;
    [SerializeField]
    public Text scoreDisplay;
    public Text scoreWinText;
    public Text scoreTimeUpText;
    public Text scoreTotalText;
    bool Finish;
    int sceneIndex;


    public void Start()
    {

        TotalScore = GetTotalScore();
        Finish = false;


        sceneIndex = SceneManager.GetActiveScene().buildIndex;



    }

    private void Update()
    {

        scoreDisplay.text = score.ToString();
        scoreWinText.text = score.ToString() + "$";
        

        // if (score >= scoreForWin && Finish == false)
        // {
        //     TotalScore += score;
        //     PlayerPrefs.SetInt("TotalScore", TotalScore);

        //     if (GetLevelScore() < score)
        //     {
        //         PlayerPrefs.SetInt("LevelStars" + sceneIndex, score);
        //         Debug.Log(PlayerPrefs.GetInt("LevelStars" + sceneIndex));

        //     }

        //     PlayerPrefs.SetInt("LastScore", score);
        //     Camera.main.GetComponent<UIManager>().Win();
        //     LevelController.instance.isEndGame();


        //     Finish = true;
        // }

    }

    public void DestroyBonus(int x)
    {

        score = score + x;
        PlayerPrefs.SetInt("score", score);

    }

    public int GetTotalScore()
    {
        if (PlayerPrefs.HasKey("TotalScore"))
        {
            return PlayerPrefs.GetInt("TotalScore");
        }
        else
        {
            return 0;
        }
    }

    public int GetLevelScore()
    {
        if (PlayerPrefs.HasKey("LevelStars" + sceneIndex))
        {

            return PlayerPrefs.GetInt("LevelStars" + sceneIndex, score);
        }
        else
        {
            Debug.Log("return 000000000000000000000000");
            return 0;
        }
    }



}
