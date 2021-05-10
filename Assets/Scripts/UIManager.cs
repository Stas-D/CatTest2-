
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;


public class UIManager : MonoBehaviour
{
[SerializeField] private GameObject panelPause;
[SerializeField] private GameObject PauseButton;
[SerializeField] private GameObject panelLose;
[SerializeField] private GameObject panelWin;
[SerializeField] private GameObject panelTimeUp;
private GameTimer timerMy;

 private CowController player;
public Transform playerPos;
public GameObject[] players;
int sceneIndex;
public GameObject loadingScreen;
    
public Slider bar;


  private void Awake() {
    player = Instantiate(players[PlayerPrefs.GetInt("Player")], playerPos.position, Quaternion.identity).GetComponent<CowController>();

}


public  void Start () {
    
    timerMy = FindObjectOfType<GameTimer>();
    

}


public void PauseOn () {
    panelPause.SetActive (true);
    Time.timeScale = 0;
    PauseButton.GetComponent<Button>().interactable = false;
    
}

public void PauseOff () {
    panelPause.SetActive (false);
    Time.timeScale = 1;
    PauseButton.GetComponent<Button>().interactable = true;
    
}
public void Lose () {
    panelLose.SetActive (true);
    Time.timeScale = 0;
    PauseButton.GetComponent<Button>().interactable = false;
    
    
}

public void TimeUp () {
   panelTimeUp.SetActive (true);
    Time.timeScale = 0;
    PauseButton.GetComponent<Button>().interactable = false;
}

public void Win () {
    panelWin.SetActive (true);
    Time.timeScale = 0;
    PauseButton.GetComponent<Button>().interactable = false;
}

public void Restart () {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    Time.timeScale = 1;
    PauseButton.GetComponent<Button>().interactable = true;
    
}

public void NextLevelWin () {
    sceneIndex = SceneManager.GetActiveScene().buildIndex;
   
 if (sceneIndex == 6)
        { 
            SceneManager.LoadScene("menu-levels");
        }
        else
        {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
        Time.timeScale = 1;
        }

    
}


public void NextLevelWinLoading () {
    sceneIndex = SceneManager.GetActiveScene().buildIndex;
   
 if (sceneIndex == 6)
        { 
            SceneManager.LoadScene("menu-levels");
        }
        else
        {
        loadingScreen.SetActive(true);
        StartCoroutine(LoadAsync());
        //ceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
        Time.timeScale = 1;
        }

    
}

IEnumerator LoadAsync () 
{
    AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex +1);
    while (!asyncLoad.isDone)
    {
        bar.value = asyncLoad.progress;
        Debug.Log("AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneIndex +1);");
        yield return null;
    }
}


 public void MainMenu () {
    SceneManager.LoadScene("main-menu");
}

 public void ToTheCity () {
    SceneManager.LoadScene("menu-levels");
    Time.timeScale = 1;
}

public void PlayPressed()
    {
        SceneManager.LoadScene("SampleScene");
    }


}
 
