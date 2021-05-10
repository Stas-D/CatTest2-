using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class buyScript : MonoBehaviour
{
public bool isPurchased;
public string ppname;
public Text priceText;
public int price;
public int purch;
public int playerIndex;
private int TotalScore;


private void Awake() {
  

}

        void Start()
    {
        
        purch = PlayerPrefs.GetInt(ppname, 0);
        TotalScore = PlayerPrefs.GetInt("TotalScore");

if (purch == 0)
{
    priceText.text = price + "$";
}
else{
    priceText.text  = Lean.Localization.LeanLocalization.GetTranslationText("catyours");
    isPurchased = true;
}
        
    }

    void Update()
    {
       
    }

    // Update is called once per frame
    public void buy () {
    if (TotalScore >= price && isPurchased == false)
    {
        PlayerPrefs.SetInt(ppname, 1);
        TotalScore -= price;
        priceText.text = Lean.Localization.LeanLocalization.GetTranslationText("catyours");
        isPurchased = true;
        PlayerPrefs.SetInt("TotalScore", TotalScore);
        StartCoroutine(select());
    }
    else if (isPurchased == true){
        StartCoroutine(select());
    }
}

IEnumerator select () {
    string lastText = priceText.text;
    priceText.text = Lean.Localization.LeanLocalization.GetTranslationText("selected");
    PlayerPrefs.SetInt("Player", playerIndex);
    yield return new WaitForSeconds(0.5f);
    priceText.text = lastText;
}


}
