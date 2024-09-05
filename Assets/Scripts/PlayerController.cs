using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 1f;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float baseSpeed = 10f;
    bool canMove = true;
    
    [SerializeField] float jumpAmount = 2f;
    //[SerializeField] float speedAmount = 5f;

    Rigidbody2D rb2d;
    SurfaceEffector2D surfaceEffector2D;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            RotatePlayer();
            RespondToBoost();
        }
        
        //Jump
      
       if(Input.GetKeyDown(KeyCode.Space))
        {
            rb2d.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
        }

        // else
        // {
        //     rb2d;
        // }

        //Speed
        /*
        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            rb2d.AddForce(Vector2.right * speedAmount, ForceMode2D.Impulse);
        }

        else if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rb2d.AddForce(Vector2.left * speedAmount, ForceMode2D.Impulse);
        }
        */
        
    }

    public void DisableControles()
    {
        canMove = false;
    }

    void RespondToBoost()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            surfaceEffector2D.speed = boostSpeed;
        }

        else
        {
           surfaceEffector2D.speed = baseSpeed;
        }
    } 

    void RotatePlayer()
    {
         if(Input.GetKey(KeyCode.LeftControl))
        {
            if(Input.GetKey(KeyCode.LeftArrow))
            {
                 rb2d.AddTorque(torqueAmount);
            }
            
            
        else if(Input.GetKey(KeyCode.RightArrow))
            {
                rb2d.AddTorque(-torqueAmount);
            }
        }
    } 
    
     
}
