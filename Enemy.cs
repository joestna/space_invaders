using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    bool left = false;
    float movimiento = 2f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < 3 && left == false)
        {
            transform.position = transform.position + new Vector3(movimiento * Time.deltaTime, 0f);
        }
        
        if(transform.position.x > 3)
        {
            left = true;
        }

        if(transform.position.x > -3 && left == true)
        {
            transform.position = transform.position + new Vector3(movimiento * Time.deltaTime * -1, 0f);
        }

        if (transform.position.x < -3)
        {
            left = false;
        }
        

    }
}
