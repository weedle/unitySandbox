using UnityEngine;
using System.Collections;

public class Particle1 : ParticleAbstract {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!active)
        {
            return;
        }
        transform.Rotate(new Vector3(0, 0, 4));
        if ( lifetime <= 0 )
        {
            Destroy(gameObject);
        } else
        {
            lifetime--;
        }
	}
}
