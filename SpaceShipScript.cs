using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipScript : MonoBehaviour
{
    public int force = 15;
    float velocidadTorpedo = 80f;
    Rigidbody2D myRB2D;
    public GameObject torpedoPrefab;
    Rigidbody2D torpedoMovement;
    bool esperaDisparo = false;

    List<GameObject> listaTorpedos = new List<GameObject>();

    void Start()
    {
        myRB2D = GetComponent<Rigidbody2D>();
    }

    
    // Evita que se puedan disparar cohetes seguidos instantaneamente
    IEnumerator espera1seg( float xPos)
    {
        esperaDisparo = true;
        yield return new WaitForSeconds(1);

        esperaDisparo = false;
    }
    

    void FixedUpdate()
    {
        float movement = Input.GetAxis("Horizontal");// * Time.deltaTime * speed;
        myRB2D.velocity = transform.right * movement * force;

        float xPos = Mathf.Clamp(transform.position.x, -6.6f, 6.6f);
        transform.position = new Vector2(xPos, myRB2D.position.y);

        // Solo se podra instanciar un nuevo torpedo si se ha pulsado el boton Jump=spaceBar y la espera para disparar ha terminado
        if (Input.GetButton("Jump") && esperaDisparo == false)
        {
            GameObject torpedo = Instantiate(torpedoPrefab, new Vector2(xPos, -5.4f), Quaternion.identity);
            listaTorpedos.Add(torpedo);

            torpedoMovement = torpedo.GetComponent<Rigidbody2D>();
            torpedoMovement.AddForce(transform.up * velocidadTorpedo);

            StartCoroutine(espera1seg(xPos));
        }


        //StartCoroutine(espera1seg(xPos));
        int i = 0;
        int tamanyoListaTorpedos = listaTorpedos.Count;
        while( i < tamanyoListaTorpedos)
        {
            GameObject torpedo = listaTorpedos[i];

            if (torpedo.GetComponent<Transform>().position.y > 3)
            {
                Destroy(torpedo);
                tamanyoListaTorpedos = listaTorpedos.Count;
                i = 0;
            }

            i++;
        }
    }
}

/*
GetAxis es la aceleraccion del GameObject hasta llegar al maximo
float movement = Input.GetAxis("Horizontal") * Time.deltaTime * speed;

if(movement != 0)
{
    //Debug.Log("El movimiento es " + movement);

    transform.Translate(movement, 0, 0);
}
*/
