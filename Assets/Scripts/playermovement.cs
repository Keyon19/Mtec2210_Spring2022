using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class playermovement : MonoBehaviour
{

    public float speed = 5.0f;
    public gamemanager gameManager;

    public float moveDuration = 0.5f;
    private float timeElapsed;
    private Vector3 targetPosition;
    private bool readyToMove = true;
    private bool isMoving = false;
   
    public enum MovementType
    {
        Continuous,
        Discrete,
    }

    public MovementType movementType;


    private void Start()
    {
        targetPosition = transform.position;
    }
     
    void Update() { 
    if (movementType == MovementType.Continuous)
        {
            ContinuousMovement();
        }
    else
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                
                //DiscreteMovement(transform.position, transform.position + Vector3.up);
            }

            if (targetPosition != transform.position)
            {
                DiscreteMovement(transform.position, targetPosition);
            }
            //DiscreteMovement();
        }
    
       
    
    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Car")
        {
            Destroy(gameObject);
            SceneManager.LoadScene("v1");
        }
    }

    private void SetTargetPosition()
    {
        targetPosition = transform.position + (Vector3.up * .5f);
    }

    private void ContinuousMovement()
    {
        float xMove = Input.GetAxisRaw("Horizontal");
        float yMove = Input.GetAxisRaw("Vertical");
        
        float xMovement = xMove * Time.deltaTime;
        float yMovement = yMove * Time.deltaTime;

        transform.Translate(xMovement, yMovement, 0);
    }

    private void DiscreteMovement(Vector3 start, Vector3 end)
    {
        if(timeElapsed < moveDuration)
        {
            timeElapsed += Time.deltaTime;

            transform.position = Vector3.Lerp(start, end, timeElapsed / moveDuration);

        }
        else
        {
            transform.position = targetPosition;
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

