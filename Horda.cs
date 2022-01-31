using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horda : MonoBehaviour
{
    bool left = false;
    float movimiento = 2f;
    bool finLateralPantalla = true;
    public bool tocaJugador = false;
    public int enemysDestroyedCount = 0;

    public List<GameObject> horde;

    void Start() { }

    void Update()
    {
        if (!tocaJugador)
        {
            if (transform.position.x < 2.5 && left == false)
            {
                transform.position += new Vector3(movimiento * Time.deltaTime, 0f);
            }

            if (transform.position.x > 2.5)
            {
                left = true;
                movimiento += 1f;

                finLateralPantalla = true;
            }



            if (transform.position.x > -2.5 && left == true)
            {
                transform.position += new Vector3(movimiento * Time.deltaTime * -1, 0f);
            }

            if (transform.position.x < -2.5)
            {
                left = false;
                movimiento += 1f;

                finLateralPantalla = true;
            }
        }

        if (finLateralPantalla)
        {
            transform.position += Vector3.down;
        }

        finLateralPantalla = false;



        if(enemysDestroyedCount >= 3)
        {
            SpaceShipScript.win = true;
            GameObject nave = GameObject.FindGameObjectWithTag("Nave");

            nave.GetComponent<SpaceShipScript>().ActiveCanvasEndGame();
        }
    }
}
