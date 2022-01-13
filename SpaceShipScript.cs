using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipScript : MonoBehaviour
{
    public int force = 15;
    float velocidadTorpedo = 200f;
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

        float xPos = Mathf.Clamp(transform.position.x, -3f, 3f);
        transform.position = new Vector2(xPos, myRB2D.position.y);

        // Solo se podra instanciar un nuevo torpedo si se ha pulsado el boton Jump=spaceBar y la espera para disparar ha terminado
        if (Input.GetButton("Jump") && esperaDisparo == false)
        {
            GameObject torpedo = Instantiate(torpedoPrefab, new Vector2(xPos, -3f), Quaternion.identity);
            listaTorpedos.Add(torpedo);

            torpedoMovement = torpedo.GetComponent<Rigidbody2D>();
            torpedoMovement.AddForce(transform.up * velocidadTorpedo);

            StartCoroutine(espera1seg(xPos));
        }
        

        // LAS DOS FORMAS SIGUIENTES CONSIGUEN HACER LO MISMO:
        // DESTRUYE LAS INSTANCIAS DE LOS OBJETOS TORPEDO CUANDO LLEGAN AL FINAL PARA QUE NO SE ALMACENEN EN MEMORIA PORQUE NO SE VOLVERAN A USAR

        /*
        if(listaTorpedos.Count > 0)
        {
            foreach (GameObject torpedo in listaTorpedos)
            {
                if (torpedo.GetComponent<Transform>().position.y > 3.5)
                {
                    listaTorpedos.Remove(torpedo);
                    Destroy(torpedo);
                }
            }
        }
        */
        
        if(listaTorpedos.Count > 0)
        {
            int i = 0;
            int tamanyoListaTorpedos = listaTorpedos.Count;
            while (i < tamanyoListaTorpedos)
            {
                GameObject torp = listaTorpedos[i];

                if (torp.GetComponent<Transform>().position.y > 3.5)
                {
                    listaTorpedos.Remove(torp);
                    Destroy(torp);
                    tamanyoListaTorpedos = listaTorpedos.Count;
                    i = -1;
                }

                i++;
            }
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
