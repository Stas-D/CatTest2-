using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    [SerializeField]
    public Text timeDisplay;
    public float timer = 90;

    private DateTime timerEnd;
    bool timerRunning = false;
    private float timeDelta = 0.0f;
    private ScoreManager sm;

    private bool TimeUp;
    int sceneIndex;
    int levelComplete;
    public int scoreForWin;
    
 



    private void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        levelComplete = PlayerPrefs.GetInt("LevelComplete");
        Debug.Log("sceneIndex is" + sceneIndex);

        sm = FindObjectOfType<ScoreManager>();
        TimeUp = false;



        // StartTimer();
    }


    public int GetLevelScore()
    {
        if (PlayerPrefs.HasKey("LevelStars" + sceneIndex))
        {

            return PlayerPrefs.GetInt("LevelStars" + sceneIndex);
        }
        else
        {
            Debug.Log("return 000000000000000000000000");
            return 0;
        }
    }

    private void Update()
    {
        //timeNow = Time.time;
        //if (timerRunning == true){
        timeDelta = Time.timeSinceLevelLoad - timer;
        TimeSpan t = TimeSpan.FromSeconds(timeDelta);
        //TimeSpan delta = timerEnd - DateTime.Now;
        //timeDisplay.text = delta.Minutes.ToString("00") + ":" + delta.Seconds.ToString("00");
        timeDisplay.text = t.ToString(@"mm\:ss");

        if (timeDelta >= 0.0 && TimeUp == false)
        {
            sm.TotalScore += sm.score;
            PlayerPrefs.SetInt("TotalScore", sm.TotalScore);


            if (GetLevelScore() < sm.score)
            {
                PlayerPrefs.SetInt("LevelStars" + sceneIndex, sm.score);
                Debug.Log(PlayerPrefs.GetInt("LevelStars" + sceneIndex, sm.score));
                Debug.Log("sceneIndex is" + sceneIndex);

            }
            if (sceneIndex == 6)
        {
            Invoke("LoadMenuLevels", 1f);
        }
        else
        {
            if (sm.score >= scoreForWin && levelComplete < sceneIndex)
            {
                PlayerPrefs.SetInt("LevelComplete", sceneIndex);

            }
        }




            Debug.Log("!!!!!!!!!" + sm.TotalScore);
            Camera.main.GetComponent<UIManager>().TimeUp();
            TimeUp = true;
            // StopTimer();
        }
        
        //}
    }
    void LoadMenuLevels()
    {
        SceneManager.LoadScene("menu-levels");
         Time.timeScale = 1;
    }

    // public void StopTimer () {
    // 	timerRunning = false;
    // }

    // public void StartTimer () {
    // 	timerRunning = true;
    // }

}