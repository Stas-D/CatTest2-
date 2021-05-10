using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuLevels : MonoBehaviour
{

    public Button Leve2Button;
    public Button Leve3Button;
    public Text Total;
    int levelComplete;
    public GameObject loadingScreen;
    
    public Slider bar;
    private int allStars;
    public Text allStarsText;



    // Start is called before the first frame update
    void Start()
    {
        

        levelComplete = PlayerPrefs.GetInt("LevelComplete");
        Leve2Button.interactable = false;
        Leve3Button.interactable = false;


        switch (levelComplete)
        {
            case 4:
                Leve2Button.interactable = true;
                Leve3Button.interactable = false;
                break;
            case 5:
                Leve2Button.interactable = true;
                Leve3Button.interactable = true;
                break;
        }
    }

    private void Update() {
        allStars =  PlayerPrefs.GetInt("AllStars");
        allStarsText.text = allStars.ToString();
    }


    public void LoadTo(int level)
    {
        
        loadingScreen.SetActive(true);
        //SceneManager.LoadScene(level);
        StartCoroutine(LoadAsync(level));
    }


IEnumerator LoadAsync (int level) 
{
    AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(level);
    while (!asyncLoad.isDone)
    {
        bar.value = asyncLoad.progress;
        yield return null;
    }
}



    public void Reset()
    {
        Leve2Button.interactable = false;
        Leve3Button.interactable = false;
        Total.text = "0" ;
        PlayerPrefs.DeleteAll();
    }

   
    

    public void MainMenu()
    {
        SceneManager.LoadScene("main-menu");
    }
}
