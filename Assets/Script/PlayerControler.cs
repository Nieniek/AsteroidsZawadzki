using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        //dodaj do wsp�lrzednych warto�� x=1, y=0, z=0 pomnozone przez czas
        //mierzony w sekundach od osztatniej klatki
        transform.position += new Vector3(1, 0, 0) * Time.deltaTime;

    }
}
