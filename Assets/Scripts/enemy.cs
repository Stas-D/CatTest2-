using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
   [SerializeField] private float speed;
   [SerializeField] private float speedBoost;
   [SerializeField] private float jump;
   [SerializeField] private float distanceAngry;
   [SerializeField] private float distancePatrol;
   private float minDistance;
   private float maxDistance;
   private Rigidbody2D rb;
   private bool patrol = true;
   private GameObject player;


private void Start () 
{
    player = GameObject.Find("Player");
    rb = GetComponent<Rigidbody2D>();
    minDistance = transform.position.x - distancePatrol; 
    maxDistance = transform.position.x + distancePatrol; 
}

private void Update () 
{
    if (patrol == true)
    Patrol();
    
}

private void Patrol() 
{
transform.Translate(transform.right * speed * Time.deltaTime);
if (transform.position.x > maxDistance)
{
    speed = -speed;
    transform.rotation = Quaternion.Euler (0,0,0);
}
if (transform.position.x < minDistance)
{
    speed = -speed;
    transform.rotation = Quaternion.Euler (0,180,0);
}
}



}
