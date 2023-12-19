using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEnter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    void OnCollisionEnter2D(Collision2D col)
    {
   
        GetComponent<PlayerController>().enabled = false;

    }
}