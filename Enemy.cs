using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Horda horde;
    bool destroyed = false;

    void Start() {}

    public void setDestroyed(bool value)
    {
        horde.enemysDestroyedCount += 1;
        destroyed = true;

        Destroy(this.gameObject);
    }

    public bool getDestroyed()
    {
        return destroyed;
    }

    void Update() { }
}
