using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{

    Transform player;

    public GameObject StaticAsteroid;

    float timeSinceSpawn;

    // Start is called before the first frame update
    void Start()
    {
        
        player = GameObject.FindWithTag("Player").transform;

        timeSinceSpawn = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceSpawn += Time.deltaTime;
        

        if (timeSinceSpawn > 1)
        {
            GameObject asteroid = SpawnAsteroid(StaticAsteroid);
            timeSinceSpawn = 0;
        }
    }

    GameObject SpawnAsteroid(GameObject prefab)
    {

        Vector3 randomPosition = Random.onUnitSphere * 10;

        randomPosition += player.position;

        GameObject asteroid = Instantiate(StaticAsteroid, randomPosition, Quaternion.identity);

        return asteroid;
    }
}
