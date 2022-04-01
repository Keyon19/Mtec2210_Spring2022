using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carmovement : MonoBehaviour
{
    public float speed = 5;

    void Start()
    {
    }
    void Update()
    {
        float x = speed * Time.deltaTime;
        transform.Translate(x, 0, 0);   
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }

}
