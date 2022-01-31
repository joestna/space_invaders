using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Torpedo : MonoBehaviour
{
    int contador = 0;

    void Start() {}
    void Update() {}

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

        if(collision.tag == "Enemy")
        {
            GameObject enemyCollision = collision.gameObject;
            Debug.Log(enemyCollision.name);

            enemyCollision.GetComponent<Enemy>().setDestroyed(true);

            Destroy(this.gameObject);
        }
    }
}
