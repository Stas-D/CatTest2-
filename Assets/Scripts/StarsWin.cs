using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StarsWin : MonoBehaviour
{
public int scoresForStar1;
public int scoresForStar2;
public int scoresForStar3;

public int levelIndex;
private GameObject star1;
private GameObject star2;
private GameObject star3;
private ScoreManager sm;

    // Start is called before the first frame update
    void Start()
    {
         sm = FindObjectOfType<ScoreManager>();
        
        if (sm.score >= scoresForStar1)
        {
            star1 = this.gameObject.transform.GetChild(0).gameObject;
            star1.SetActive(true);
        }
         if (sm.score >= scoresForStar2)
        {
            star2 = this.gameObject.transform.GetChild(1).gameObject;
            star2.SetActive(true);
        }
         if (sm.score >= scoresForStar3)
        {
            star3 = this.gameObject.transform.GetChild(2).gameObject;
            star3.SetActive(true);
        }
        


        
    }
    public int GetLevelScore()
    {
        if (PlayerPrefs.HasKey("LevelStars" +  levelIndex))
        {
          
            return PlayerPrefs.GetInt("LevelStars" +  levelIndex);
        }
        else
        {
          Debug.Log("return 000000000000000000000000");
            return 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
