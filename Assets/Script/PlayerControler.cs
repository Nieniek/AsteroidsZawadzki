using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float rotationSpeed = 100f;
    public float flySpeed = 5f;
   
    GameObject levelManagerObject;
    
    float shieldCapacity = 1;

    
    void Start()
    {
        levelManagerObject = GameObject.Find("LevelManager");
    }

    
    void Update()
    {
        
        Vector3 movement = transform.forward;
       
        movement *= Time.deltaTime;
      
        movement *= Input.GetAxis("Vertical");
      
        movement *= flySpeed;
     

       
        Rigidbody rb = GetComponent<Rigidbody>();
       
        rb.AddForce(movement, ForceMode.VelocityChange);


        
        Vector3 rotation = Vector3.up;
       
        rotation *= Time.deltaTime;
        
        rotation *= Input.GetAxis("Horizontal");
       
        rotation *= rotationSpeed;
       
        transform.Rotate(rotation);
        UpdateUI();
    }

    private void UpdateUI()
    {
        
        Vector3 target = levelManagerObject.GetComponent<LevelManager>().exitPosition;
      
        transform.Find("NavUI").Find("TargetMarker").LookAt(target);
       
        TextMeshProUGUI shieldText =
            GameObject.Find("Canvas").transform.Find("ShieldCapacityText").GetComponent<TextMeshProUGUI>();
        shieldText.text = " Shield: " + (shieldCapacity * 100).ToString() + "%";

        
        if (levelManagerObject.GetComponent<LevelManager>().levelComplete)
        {
           
            GameObject.Find("Canvas").transform.Find("LevelCompleteScreen").gameObject.SetActive(true);
        }
       
        if (levelManagerObject.GetComponent<LevelManager>().levelFailed)
        {
           
            GameObject.Find("Canvas").transform.Find("GameOverScreen").gameObject.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.collider.transform.CompareTag("Asteroid"))
        {

            Transform asteroid = collision.collider.transform;
           
            Vector3 shieldForce = asteroid.position - transform.position;
          
            asteroid.GetComponent<Rigidbody>().AddForce(shieldForce * 5, ForceMode.Impulse);
            shieldCapacity -= 0.25f;
            if (shieldCapacity <= 0)
            {
                
                levelManagerObject.GetComponent<LevelManager>().levelFailed = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.transform.CompareTag("LevelExit"))
        {
            
            levelManagerObject.GetComponent<LevelManager>().levelComplete = true;
        }
    }
}
