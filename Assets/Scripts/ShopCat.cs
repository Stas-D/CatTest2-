using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopCat : MonoBehaviour
{
    private ScoreManager sm;
    private int TotalScore;
     private Text priceText;
    [SerializeField] private int [] price;
    // Start is called before the first frame update
private void Awake() {
    sm = GameObject.FindGameObjectWithTag ("ScoreManager").GetComponent<ScoreManager>();
}

    void Start()
    {
        
        TotalScore = sm.GetTotalScore();
        
    }

    // Update is called once per frame
    


public void buy () {

}

    // private void PriceDetection () {
    //     if (TotalScore >= price [index])
    //     priceText.color = Color.green;
    //     else{
    //         priceText.color = Color.red;
    //     }
    // }
}
