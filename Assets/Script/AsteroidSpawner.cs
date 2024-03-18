#nullable enable
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
        

        if (timeSinceSpawn > 0.1)
        {
            GameObject asteroid = SpawnAsteroid(StaticAsteroid);
            timeSinceSpawn = 0;
        }
        AsteroidCountControll();
    }

    GameObject SpawnAsteroid(GameObject prefab)
    {

       
        
            Vector2 randomCirclePosition = Random.insideUnitCircle.normalized;

            Vector3 randomPosition = new Vector3(randomCirclePosition.x, 0, randomCirclePosition.y) * 10;

            randomPosition += player.position;

            if (!Physics.CheckSphere(randomPosition, 5))
            {

                GameObject asteroid = Instantiate(StaticAsteroid, randomPosition, Quaternion.identity);

                return asteroid;

            }
        else
        {
            return null;
        }
    }
    void AsteroidCountControll()
    {
        GameObject[] asteroids = GameObject.FindGameObjectsWithTag("Asteroid");

        foreach (GameObject asteroid in asteroids)
        {
            Vector3 delta = player.position - asteroid.transform.position;
            
            float distanceToPlayer = delta.magnitude;

            if (distanceToPlayer > 30) 
            {
            
            Destroy(asteroid);
            
            }

        }
    }
}
