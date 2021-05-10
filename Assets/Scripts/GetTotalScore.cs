using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetTotalScore : MonoBehaviour
{

    public int TotalScore;
    private ScoreManager sm;
    public Text scoreTotalText;
    
    
    // Start is called before the first frame update
    void Start()
    {
             
    }

    private void Update() {
           TotalScore = PlayerPrefs.GetInt("TotalScore");
         sm = FindObjectOfType<ScoreManager>();
        scoreTotalText.text = TotalScore.ToString(); 
        
        
    }

    
}
