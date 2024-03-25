using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public float rotationSpeed = 100f;
    public float flySpeed = 5f;

    GameObject levelMenagerObject;

    // Start is called before the first frame update
    void Start()
    {
        levelMenagerObject = GameObject.Find("levelMenager");
    }

    // Update is called once per frame
    void Update()
    {
        //dodaj do wspólrzednych wartoœæ x=1, y=0, z=0 pomnozone przez czas
        //mierzony w sekundach od osztatniej klatki
        //transform.position += new Vector3(1, 0, 0) * Time.deltaTime;

        //prezentacja dzia³anie wyg³adzonego sterowania (emulacji joystika)
        //Debug.Log(Input, GetAxis("Vertival"));

        //sterowanie predkoscia
        //stworz nowy wektor przesuniecia o wartosc 1 do przodu
        Vector3 movment = transform.forward;
        //pomnorzyc przez czas od ostatniej klatki
        movment *= Time.deltaTime;
        //pomnoz go przez "wychylenie joysticka"
        movment *= Input.GetAxis("Vertical");
        //pomnoz przez predkosc lotu
        movment *= flySpeed;
        //dodaj ruch do obiektu
        //---transform.position += movment;
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(movment, ForceMode.VelocityChange);

        //obrot

        //modyfikuj oœ "Y" obiektu player
        Vector3 rotation = Vector3.up;
        //przemonz przez czas
        rotation *= Time.deltaTime;
        //przemnoz przez klawiature
        rotation *= Input.GetAxis("Horizontal");
        //pomnoz przez prêdkoœæ obrotu
        rotation *= rotationSpeed;

        //dodaj obrot do obiektu
        //nie mozemy uzyc += poniewaz unity uzywa quaterenionow do zapisu rotacji
        transform.Rotate(rotation);
        UpdateUI();
    }

    private void UpdateUI()
    {
        Vector3 target = levelMenagerObject.GetComponent<LevelManager>().exitPosition;

        transform.Find("NavUI").Find("TargetMarker").LookAt(target);
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.transform.CompareTag("Asteroid"))
        {

            Debug.Log("Boom!");

            Time.timeScale = 0;
        }
    
    }
}
