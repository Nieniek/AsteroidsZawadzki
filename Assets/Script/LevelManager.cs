using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    Transform player;
   
    public float levelExitDistance = 100;
   
    public Vector3 exitPosition;
    public GameObject exitPrefab;
    
    public bool levelComplete = false;
    
    public bool levelFailed = false;
    
    void Start()
    {
        //znajdz gracza
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
        Vector2 spawnCircle = Random.insideUnitCircle;
        
        spawnCircle = spawnCircle.normalized; 
        spawnCircle *= levelExitDistance; 
        
        exitPosition = new Vector3(spawnCircle.x, 0, spawnCircle.y);
        Instantiate(exitPrefab, exitPosition, Quaternion.identity);

        Time.timeScale = 1f;
    }

    
    void Update()
    {

    }
    public void OnSuccess()
    {
        Time.timeScale = 0f;

        levelFailed = true;

        Camera.main.transform.Find("GameOverSound").GetComponent<AudioSource>().Play();
    }
    public void OnFailure()
    {
        Time.timeScale = 0f;

        levelFailed = true;
        
        Camera.main.transform.Find("GameOverSound").GetComponent<AudioSource>().Play();
    }
}