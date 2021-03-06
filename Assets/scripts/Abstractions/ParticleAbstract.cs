﻿using UnityEngine;
using System.Collections;

public abstract class ParticleAbstract : MonoBehaviour {
    public int lifetime;
    private Vector2 velKeep;
    public bool active = true;
    public ShipDefinitions.Faction faction;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update ()
    {
    }

    public void pause()
    {
        active = false;

        Rigidbody2D rbody = GetComponent<Rigidbody2D>();
        velKeep = rbody.velocity;
        rbody.velocity = Vector2.zero;

        GetComponent<Animator>().Stop();
    }

    public void unpause()
    {
        active = true;

        Rigidbody2D rbody = GetComponent<Rigidbody2D>();
        rbody.velocity = velKeep;

        GetComponent<Animator>().StartPlayback();
    }
}
