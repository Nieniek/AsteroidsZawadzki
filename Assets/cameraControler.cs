using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControler : MonoBehaviour
{//wspó³rzedne gracza
    Transform player;

    public float cameraHeight = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
    }

    // Update is called once per frame
    void Update()
    {
       Vector3 targetPosition = player.position + Vector3.up * cameraHeight;

        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime);
    }
}
