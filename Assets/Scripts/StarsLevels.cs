using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StarsLevels : MonoBehaviour
{
    public int scoresForStar1;
    public int scoresForStar2;
    public int scoresForStar3;

    public int levelIndex;
    public int starsToUnlock;
    private GameObject star1;
    private GameObject star2;
    private GameObject star3;
    private GameObject startButton;
    private GameObject message;





    // Start is called before the first frame update
    void Start()
    {

        startButton = this.gameObject.transform.GetChild(0).GetChild(9).gameObject;
        message = this.gameObject.transform.GetChild(0).GetChild(10).gameObject;

        Debug.Log("4:" + PlayerPrefs.GetInt("LevelStars4"));
        Debug.Log("5:" + PlayerPrefs.GetInt("LevelStars5"));
        Debug.Log("6:" + PlayerPrefs.GetInt("LevelStars6"));

        if (GetLevelScore() >= scoresForStar1)
        {
            star1 = this.gameObject.transform.GetChild(0).GetChild(0).gameObject;
            star1.SetActive(true);
            if (PlayerPrefs.GetInt("LevelStar1" + levelIndex) == 0)
            {
                PlayerPrefs.SetInt("LevelStar1" + levelIndex, 1);
                PlayerPrefs.SetInt("AllStars", PlayerPrefs.GetInt("AllStars") + 1);
            }

        }
        if (GetLevelScore() >= scoresForStar2)
        {
            star2 = this.gameObject.transform.GetChild(0).GetChild(1).gameObject;
            star2.SetActive(true);
            if (PlayerPrefs.GetInt("LevelStar2" + levelIndex) == 0)
            {
                PlayerPrefs.SetInt("LevelStar2" + levelIndex, 1);
                PlayerPrefs.SetInt("AllStars", PlayerPrefs.GetInt("AllStars") + 1);
            }
        }
        if (GetLevelScore() >= scoresForStar3)
        {
            star3 = this.gameObject.transform.GetChild(0).GetChild(2).gameObject;
            star3.SetActive(true);
            if (PlayerPrefs.GetInt("LevelStar3" + levelIndex) == 0)
            {
                PlayerPrefs.SetInt("LevelStar3" + levelIndex, 1);
                PlayerPrefs.SetInt("AllStars", PlayerPrefs.GetInt("AllStars") + 1);
            }
        }




    }
    public int GetLevelScore()
    {
        if (PlayerPrefs.HasKey("LevelStars" + levelIndex))
        {

            return PlayerPrefs.GetInt("LevelStars" + levelIndex);
        }
        else
        {
            return 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("AllStars") < starsToUnlock )
            {
               
               startButton.SetActive(false);
               message.SetActive(true);
            }
            else{
                startButton.SetActive(true);
                message.SetActive(false);
            }

    }
}
