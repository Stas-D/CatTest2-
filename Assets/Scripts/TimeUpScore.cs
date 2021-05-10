using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeUpScore : MonoBehaviour
{
    public Text scoreTimeUpText;
    private ScoreManager sm;

    private int score;
    void Start()
    {
        sm = FindObjectOfType<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {

      StartCoroutine("Counter");



    }
    IEnumerator Counter() 
{

    for (int i = 1; i <= sm.score; i += 5) 
    {
        scoreTimeUpText.text = i.ToString();
        
        yield return null;
    }
    scoreTimeUpText.text = sm.score.ToString();
}

}
