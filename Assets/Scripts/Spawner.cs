using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject enemy;
    public float spawnRate;

    private float nextSpawn = 0F;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Time.time > nextSpawn)
        {
        nextSpawn = Time.time + spawnRate;
        Instantiate(enemy, transform.position, enemy.transform.rotation);
        }

    }
}
