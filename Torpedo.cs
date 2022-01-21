using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torpedo : MonoBehaviour
{
    int contador = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
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
