using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class buyPowers : MonoBehaviour
{
public bool isPurchased;
public string ppnamePower;
public Text priceText;
public int price;
public int purch;
private int TotalScore;



private void Awake() {
  

}

        void Start()
    {
         
        purch = PlayerPrefs.GetInt(ppnamePower, 0);
        TotalScore = PlayerPrefs.GetInt("TotalScore");

if (purch == 0)
{
    priceText.text = price + "$";
}
else{
    priceText.text  = Lean.Localization.LeanLocalization.GetTranslationText("alreadybought");
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
        PlayerPrefs.SetInt(ppnamePower, 1);
        TotalScore -= price;
        priceText.text = Lean.Localization.LeanLocalization.GetTranslationText("alreadybought");
        isPurchased = true;
        PlayerPrefs.SetInt("TotalScore", TotalScore);
    }
    else if (isPurchased == true){
        //StartCoroutine(select());
    }
}

IEnumerator select () {
    string lastText = priceText.text;
    priceText.text = Lean.Localization.LeanLocalization.GetTranslationText("selected");
        
    yield return new WaitForSeconds(0.5f);
    priceText.text = lastText;
}




}
