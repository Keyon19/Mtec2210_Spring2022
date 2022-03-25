using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamemanager : MonoBehaviour
{
    public GameObject carPrefab;
    public Transform[] CarSpawnPoints;
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

        int dirModifier = (index > 2) ? -1 : 1;
        car.GetComponent<carmovement>().speed = Random.Range(3.0f, 6.0f) * dirModifier;
    
        
    }
}
