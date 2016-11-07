using UnityEngine;
using System.Collections;

public class Particle3 : ParticleAbstract
{
    public Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Vector3 newVel = rb.velocity;
        newVel.x += Random.Range(8, 10);
        newVel.y += Random.Range(8, 10);
        rb.velocity.Set(newVel.x, newVel.y, newVel.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (!active)
            return;
        transform.Rotate(new Vector3(0, 0, 4));
        if (lifetime <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            lifetime--;
        }
    }
}
