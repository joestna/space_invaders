using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torpedo : MonoBehaviour
{
    int contador = 0;

    void Start() {}
    void Update() {}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision);

        if(contador == 0)
        {
            contador++;
            SpaceShipScript.esperaDisparo = false;
        }
        else
        {
            Destroy(this.gameObject);
        }        
    }
}
