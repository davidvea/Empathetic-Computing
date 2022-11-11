using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int speed;
    public float xRange;
    public float yRange;
    public float zRange;
    public float negxRange;
    public float negyRange;
    public float negzRange;

    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1"))
        {
            transform.position = transform.position + Camera.main.transform.forward * speed * Time.deltaTime;
        }

        if(transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        if(transform.position.x < negxRange)
        {
            transform.position = new Vector3(negxRange, transform.position.y, transform.position.z);
        }
        
        if(transform.position.y > yRange)
        {
            transform.position = new Vector3(transform.position.x, yRange, transform.position.z);
        }

        if(transform.position.y < negyRange)
        {
            transform.position = new Vector3(transform.position.x, negyRange, transform.position.z);
        }

        if(transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }

        if(transform.position.z < negzRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, negzRange);
        }

    }
}
