using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class playermovement : MonoBehaviour
{

    public float speed = 5.0f;
    public gamemanager gameManager;

     
    void Update() {
        
        float xMove = Input.GetAxisRaw("Horizontal");
        float yMove = Input.GetAxisRaw("Vertical");

        float xMovement = xMove * Time.deltaTime;
        float yMovement = yMove * Time.deltaTime;

        transform.Translate(xMovement, yMovement, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Car")
        {
            Destroy(gameObject);
            SceneManager.LoadScene("v1");
        }
    }

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Goal")
        {
            Debug.Log("Area Cleared");
            SceneManager.LoadScene("v1");
            
        }
    }

}

