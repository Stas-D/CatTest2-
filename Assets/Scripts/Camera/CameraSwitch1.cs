using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch1 : MonoBehaviour
{


    public GameObject cameraMain;
    private CameraController cameraController;
    // public GameObject camera2Floor;
    // public bool whichCam;
    // Start is called before the first frame update
    
    
    
    void Start()
    {
       cameraController = cameraMain.GetComponent<CameraController>();

    //    camera1Floor = GameObject.FindGameObjectWithTag("MainCamera");
    //    camera2Floor = GameObject.FindGameObjectWithTag("MainCamera2");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D (Collider2D col)  
 {  
        if (col.gameObject.tag.Equals("Player"))
        {
            cameraController.TheFirstFloor();     
        
    }

}
}




//  if (whichCam == false)
//             {
//                 whichCam = true;
//             }
//             else if (whichCam == true)
//             {
//                 whichCam = false;
//             }
//         }
//         if (whichCam == false)
//         {
//             camera1Floor.SetActive (true);
//             camera2Floor.SetActive (false);
//         }
//          if (whichCam == true)
//         {
//             camera1Floor.SetActive (false);
//             camera2Floor.SetActive (true);
//         }
