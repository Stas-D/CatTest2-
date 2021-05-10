using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy2 : MonoBehaviour
{
    [SerializeField]
    public int points = 20;
    public GameObject destroyedVersion;

    private ScoreManager sm;

    public static Rigidbody2D rb;
    public float force;



    private void Start()
    {
        sm = FindObjectOfType<ScoreManager>();

    }

    void FixedUpdate()
    {
        rb = GetComponent<Rigidbody2D>();

    }


    public void OnCollisionEnter2D(Collision2D collision)


    {
        Vector3 vel = rb.velocity;
        Debug.Log("Неразбился" + collision.relativeVelocity.magnitude);

        if (collision.gameObject.tag.Equals("Floor") | collision.gameObject.tag.Equals("Destroyed") 
        | collision.gameObject.tag.Equals("Undestroyed")
        && collision.relativeVelocity.magnitude > 12)
        {
           
            sm.DestroyBonus(points);
            VaseBroke();

        }
    }



    public void VaseBroke()
    {
        Instantiate(destroyedVersion, transform.position, transform.rotation);
        SoundManager.snd.PlayVaseSounds();
        Destroy(gameObject);
    }


}



//  public void OnTriggerEnter2D (Collider2D col)
//  {
//      Vector3 vel = rb.velocity;

//  if (col.gameObject.tag.Equals("Floor")){

//  Debug.Log("Неразбился" + vel.magnitude);}
// if (col.gameObject.tag.Equals ("Floor") && vel.magnitude > 6)
// {
// Debug.Log("Разбился" + vel.magnitude);
// sm.DestroyBonus(points);
// VaseBroke();

// }
// }