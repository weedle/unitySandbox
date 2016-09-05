using UnityEngine;
using System.Collections;

public class Particle : MonoBehaviour {
    int lifetime = 50;

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
        print(lifetime);
	}
}
