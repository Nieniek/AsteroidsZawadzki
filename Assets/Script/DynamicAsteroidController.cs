using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicAsteroidController : MonoBehaviour
{
    GameObject player;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");

        transform.LookAt(player.transform.position);

        rb = GetComponent<Rigidbody>();

        rb.AddForce(transform.forward, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {

    }
}