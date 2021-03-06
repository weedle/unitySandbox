﻿using UnityEngine;
using System.Collections;

public class ImplFlamethrowerFiringModule : MonoBehaviour, IntfFiringModule
{
    public int counter = 0;
    public ParticleAbstract projectile;
    public float projectileSpeed = 20;
    public int ammoMax = 15;
    public int ammunition = 15;
    public int ammoCooldown = 80;

    // Use this for initialization
    void Start ()
    {
        projectileSpeed += Random.Range(-4, 4);
        ammoMax += Random.Range(-4, 4);
        ammoCooldown += Random.Range(-20, 20);
    }
	
	// Update is called once per frame
	void Update ()
    {
        counter++;
        if (counter >= ammoCooldown)
        {
            if (ammunition < ammoMax)
            {
                ammunition = ammoMax;
                counter = 0;
            }
        }
    }

    public void fire()
    {
        if (ammunition > 0)
        {
            Vector3 vec;
            Vector3 temp;
            Rigidbody2D proj;
            vec = new Vector3(0, (float)0.25, 0);
            vec = transform.rotation * vec;
            for (int i = 0; i <= 3; i++)
            {
                temp = new Vector3(transform.position.x, transform.position.y);
                proj = (Rigidbody2D)Instantiate(projectile.GetComponent<Rigidbody2D>(), 
                    temp + vec, Quaternion.Euler(0, 0, 90));
                temp = new Vector3(projectileSpeed * vec.x, projectileSpeed * vec.y, 0);
                proj.velocity = temp;
                //proj.MoveRotation(proj.transform.rotation.eulerAngles.z
                //    + Random.Range(-15, 15));
            }
            ammunition--;
            temp = Vector3.zero;
            vec = Vector3.zero;
        }
    }

    public float getEffectiveDistance()
    {
        return 2;
    }

    public float getEffectiveAngle()
    {
        return 4;
    }
    
    public void setFaction(ShipDefinitions.Faction faction)
    {
        projectile.faction = faction;
    }

    public bool canFire()
    {
        if (ammunition > 0) return true;
        else return false;
    }
}
