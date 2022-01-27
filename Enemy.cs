using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    bool left = false;
    float movimiento = 2f;
    bool finLateralPantalla = true;


    void Start() {}


    void Update()
    {
        if (transform.position.x < 6.5 && left == false)
        {
            transform.position += new Vector3(movimiento * Time.deltaTime, 0f);
            //transform.position += Vector3.right * Time.deltaTime;
        }
        
        if(transform.position.x > 6.5)
        {
            left = true;
            movimiento += 1f;

            finLateralPantalla = true;
        }



        if(transform.position.x > -6.5 && left == true)
        {
            transform.position += new Vector3(movimiento * Time.deltaTime * -1, 0f);
        }

        if (transform.position.x < -6.5)
        {
            left = false;
            movimiento += 1f;

            finLateralPantalla = true;
        }



        if (finLateralPantalla)
        {
            transform.position += Vector3.down;
        }

        finLateralPantalla = false;
    }
}
