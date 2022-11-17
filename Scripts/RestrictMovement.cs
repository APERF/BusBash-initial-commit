using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestrictMovement : MonoBehaviour
{
    //Variables START
    private float zBoundsUp = -20f;
    private float zBoundsDown = -20f;
    private float xBounds = 8f;
    //Variables END

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Restrict How Far the Player Can Go Up
        if(transform.position.z > zBoundsUp)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBoundsUp);
        }

        //Restrict How Far the Player Can Go Down
        else if (transform.position.z < zBoundsDown)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBoundsDown);
        }

        //Restrict How Far the Player Can Go Left
        if (transform.position.x > xBounds)
        {
            transform.position = new Vector3(xBounds, transform.position.y, transform.position.z);
        }

        //Restrict How Far the Player Can Go Right
        else if (transform.position.x < -xBounds)
        {
            transform.position = new Vector3(-xBounds, transform.position.y, transform.position.z);
        }
    }
}
