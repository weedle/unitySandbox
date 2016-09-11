using UnityEngine;
using System.Collections;

public abstract class ParticleAbstract : MonoBehaviour {
    int lifetime = 10;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	    if( lifetime <= 0 )
        {
            Destroy(gameObject);
        } else
        {
            lifetime--;
        }
	}
}
