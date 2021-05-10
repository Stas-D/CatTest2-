using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class CowController : MonoBehaviour
{
    public float speed;
    public float normalSpeed;
    public float jumpForce;
    private float moveInput;
    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    [SerializeField]
    public LayerMask whatIsGround;
    

    float dirX;
    [SerializeField]
    float moveSpeed = 5f;
    public static Rigidbody2D rb;
    [SerializeField]


    public float lives;
    public int numOfHearts;
    public Image[] hearts;
    public Sprite HeartFull;
    public Sprite HeartEmpty;
    private Animator anim;
    private GameObject LivesHearts;


    void Start()
    {
        feetPos = gameObject.transform.Find("feetPos").transform;
        anim = GetComponent <Animator> ();
        speed = 0f;
        rb = GetComponent<Rigidbody2D>();
        LivesHearts = GameObject.FindGameObjectWithTag("Lives");
        hearts[0] = LivesHearts.transform.GetChild(0).GetComponent<Image>();; 
        hearts[1] = LivesHearts.transform.GetChild(1).GetComponent<Image>();; 
        hearts[2] = LivesHearts.transform.GetChild(2).GetComponent<Image>();; 
        
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpForce;
            anim.SetTrigger("takeOff");
        }

        if (isGrounded == true)
        {
            anim.SetBool("isJumping", false);
        }
        else 
        {
            anim.SetBool("isJumping", true);
        }

       
        
    }

    private void FixedUpdate()
    {

        if (lives > numOfHearts)
        {
            lives = numOfHearts;
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < Mathf.RoundToInt(lives))
            {
                hearts[i].sprite = HeartFull;
            }
            else
            {
                hearts[i].sprite = HeartEmpty;
            }
            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
            if (lives < 1)
            {
                Camera.main.GetComponent<UIManager>().Lose();
                
            }
        }


        rb.velocity = new Vector2(speed, rb.velocity.y);
        if (speed !=0f){
            anim.SetBool("isRunning", true);
        }
        


    }


    
    public void OnJumpbuttonDown()
    {
         if (isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
            anim.SetTrigger("takeOff");
        }
    }

    public void OnLeftButtonDown()
    {
        if (speed <= 0f)
        {
            speed = -normalSpeed;
            transform.eulerAngles = new Vector3 (0,180,0);
            
        }
        
    }

    public void OnRightButtonDown()
    {
        if (speed >= 0f)
        {
            speed = normalSpeed;
            transform.eulerAngles = new Vector3 (0,0,0);
            
        }
        
    }

    public void OnButtonUp()
    {
        speed = 0f;
        anim.SetBool("isRunning", false);
    }



    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            lives--;
        }
    }

}
