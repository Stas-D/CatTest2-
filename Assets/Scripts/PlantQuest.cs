using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlantQuest : MonoBehaviour
{
    public bool Used;
    public Animator[] plant;
    public Animator[] bull;
    public Button btn;
    public MyButton myScript;
    public int points = 20;
    private ScoreManager sm;
    private GameObject plantTip;
    public GameObject GroundParticles;
        public AudioClip crashPlant;
        private AudioSource source;
    
    
   
    private void Awake() {
         source = GetComponent<AudioSource>();
    }

     void Start()
    {
        
        sm = FindObjectOfType<ScoreManager>();
        bull = GameObject.FindGameObjectWithTag("Player").GetComponents<Animator>();
        plantTip = gameObject.transform.GetChild(1).gameObject;
       
    //    myScript = (MyButton) btn;
        //Calls the TaskOnClick/TaskWithParameters/ButtonClicked method when you click the Button        
    }
    public void OnTriggerEnter2D (Collider2D other)
    {      
        if(Used == false && PlayerPrefs.GetInt("plant1") == 1){ 
        if (other.CompareTag("ActiveCollaider")) {
            
            foreach(Animator anim in plant) {
                anim.SetTrigger("IsTriggered");
                if(PlayerPrefs.GetInt("PlanttipUsed") == 0){
                      plantTip.SetActive(true);
                      
                      
                }

                                   
                     btn.onClick.AddListener(Do);
                     
                    
                    
                                                    
            }
            }
        }
    }


    public void Do () {
        foreach(Animator anim in plant) {
    anim.SetTrigger("Done");}
    foreach(Animator anim in bull) {
                anim.SetTrigger("action1");}
    Instantiate (GroundParticles, transform.position, Quaternion.identity);
    sm.DestroyBonus(points);
    source.PlayOneShot(crashPlant);

    plantTip.SetActive(false);
    PlayerPrefs.SetInt("PlanttipUsed", 1);

    Used = true;
    btn.onClick.RemoveListener(Do);
    }


  public void OnTriggerExit2D (Collider2D other)
    {
        if (other.CompareTag("ActiveCollaider")&& PlayerPrefs.GetInt("plant1") == 1)
        {
            foreach(Animator anim in plant)
            {
                anim.SetTrigger("IsTriggered");
            }
            Invoke ("TipHide", 2);
            btn.onClick.RemoveListener(Do);
        }
    }
     private void TipHide () {
        plantTip.SetActive(false);
    }

}

/*

 public void OnTriggerEnter2D (Collider2D other)
    {      
        if(Used == false){ 
        if (other.CompareTag("Player")) {
            
            foreach(Animator anim in box) {
                anim.SetTrigger("IsTriggered");
                
                     btn.onClick.AddListener(() => {
                    anim.SetTrigger("Done");
                    
                    Used = true;
                    sm.DestroyBonus(points);
                });

            }
            }
        }
    }
*/