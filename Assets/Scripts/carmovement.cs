using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carmovement : MonoBehaviour
{
    public float speed = 5;
    
    void Update()
    {
        float x = speed * Time.deltaTime;
        transform.Translate(x, 0, 0);
    }
}
