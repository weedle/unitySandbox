﻿using UnityEngine;
using System.Collections;

public class Particle2 : ParticleAbstract
{
    float spinrate = 4;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, spinrate));
        if (lifetime <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            lifetime--;
        }
        /*
        if(lifetime % 5 == 0)
        {
            //print(distBetween(transform.position, MachineDefinitions.getCursor()));
            float dist = distBetween(transform.position, MachineDefinitions.getCursor());
            if (dist == 0) dist = 0.01F;
            spinrate = 10/dist;
        } */

    }

    public float distBetween(Vector3 a, Vector3 b)
    {
        a.x = b.x - a.x;
        a.y = b.y - a.y;
        a.z = b.z - a.z;

        a.x = a.x * a.x;
        a.y = a.y * a.y;
        a.z = a.z * a.z;

        a.x = a.x + a.y + a.x;
        a.x = Mathf.Sqrt(a.x);

        return a.x;




    }
}
