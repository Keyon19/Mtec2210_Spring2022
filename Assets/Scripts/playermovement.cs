using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{

    public float speed = 5.0f;
   
    void Update()
    {
        float xMove = Input.GetAxis("Horizontal");
        float xMovement = xMove * Time.deltaTime;
 

        float yMove = Input.GetAxis("Vertical");
        float yMovement = yMove * Time.deltaTime;
        
        transform.Translate(xMovement, yMovement, 0);
    }
}