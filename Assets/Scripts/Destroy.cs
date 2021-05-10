using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    
  //  public GameObject destroyedVersion;
 //   static float dirX;
 public static Rigidbody2D rb;


//public class GroundForVase : MonoBehaviour
//{
  
 
void FixedUpdate () {
  rb = GetComponent<Rigidbody2D>();
    
}
  
  
  void OnTriggerEnter2D(Collider2D col)  
 {
     Vector3 vel = rb.velocity;

 if (col.gameObject.tag.Equals("Floor")){
 Debug.Log("HitGround222222222");}
if (col.gameObject.tag.Equals ("Floor") && vel.magnitude <-10)
{
Debug.Log("death222");

}
}
//}



  

 //   public void ExplodeTheObject () {
 //       Instantiate(destroyedVersion, transform.position, transform.rotation);
 //       Destroy(gameObject);
 //   }
}


//     function OnCollisionEnter()
 //    {
//     dCrate = Instantiate(DestroyedCrate,transform.position,Quaternion.identity) as Rigidbody;
 //    dCrate.velocity = rigidbody.velocity; // Assign the velocity of current game object to instantiated dCrate.
 //    Destroy(gameObject); 
//     }