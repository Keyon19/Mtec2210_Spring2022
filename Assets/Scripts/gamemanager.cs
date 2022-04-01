using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamemanager : MonoBehaviour
{
    public GameObject carPrefab;
    public Transform[] CarSpawnPoints;
    public Color[] carColors;
 
   
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnCar();
        }

        
        
    }

    void SpawnCar() 
    { 


        int index = Random.Range(0, CarSpawnPoints.Length);
       
        Vector3 spawnPos = CarSpawnPoints[index].position;

        GameObject car = Instantiate(carPrefab,spawnPos,Quaternion.identity);

        int dirModifier = 0;
        if (index > 2)
        {
            dirModifier = - 1;
            car.GetComponent<SpriteRenderer>().flipX = true;
        } else
        {
            dirModifier = 1;
            car.GetComponent<SpriteRenderer>().flipX = false;
        }
        //int dirModifier = (index > 2) ? -1 : 1;

        float newSpeed = Random.Range(3.0f, 6.9f);
        //int colorIndex = Mathf.FloorToInt(newSpeed) - 3;

        car.GetComponent<carmovement>().speed = newSpeed * dirModifier;

        
        
        Color c = Color.black;

        if (newSpeed < 4.0f)
        {
            c = carColors[0];
        }else if(newSpeed>= 4.0f && newSpeed < 4.5f)
        {
            c = carColors[1];
        }
        else if (newSpeed >= 4.5f && newSpeed < 5.5f)
        {
            c = carColors[2];
        }
        else 
        {
            c = carColors[3];
        }

       
        car.GetComponent<SpriteRenderer>().color = c;
        
        //car.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));

        //car.GetComponent<SpriteRenderer>().color = carColors[colorIndex];


    }


}
