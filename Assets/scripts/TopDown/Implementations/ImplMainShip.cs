﻿using UnityEngine;
using System.Collections;

public class ImplMainShip : MonoBehaviour, IntfShip
{
    public bool inactive;
    public int rotationSpeed = 5;
    public float moveSpeed = 1;
    private string shipName;
    public GameObject health;
    public GameObject text;
    public float healthPoints = 10;
    public float maxHealth = 10;
    private Vector2 velKeep;

    // Use this for initialization
    void Start () {
        rotationSpeed += Random.Range(-2, 2);
        moveSpeed += Random.Range(-0.3f, 0.3f);
        //Camera camera = Camera.main;
        //camera.orthographicSize = 640 / Screen.width * Screen.height / 2;
        shipName = ShipDefinitions.generateName();
    }
	
	// Update is called once per frame
	void Update () {
        // If the ship is out of bounds, Bounds.getPosInBounds
        // will return a new position within bounds
        transform.position = Bounds.getPosInBounds(transform.position);
    }

    public ShipDefinitions.SState getState()
    {
        return ShipDefinitions.SState.Inactive;
    }

    public float getAngle()
    {
        return (transform.rotation.eulerAngles.z + 90) * Mathf.PI / 180;
    }

    public void brake()
    {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = rigidbody.velocity * (float)0.90;
    }

    public void move(float vertical)
    {
        Vector2 temp = new Vector2(Mathf.Cos(getAngle()),
                Mathf.Sin(getAngle()));
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        if(vertical != 0)
            rigidbody.velocity = temp * moveSpeed * (vertical + Mathf.Sign(vertical));
        temp = Vector3.zero;
    }

    public void rotate(float horizontal)
    {
        Vector3 temp = new Vector3(0, 0, -1 * rotationSpeed * horizontal);
        if (horizontal != 0)
            transform.Rotate(temp);
        temp = Vector3.zero;
    }


    public void fire()
    {
        GetComponent<IntfFiringModule>().fire();
    }
    
    public float getEffectiveDistance()
    {
        return GetComponent<IntfFiringModule>().getEffectiveDistance();
    }

    public float getEffectiveAngle()
    {
        return GetComponent<IntfFiringModule>().getEffectiveAngle();
    }

    public void start()
    {
        enabled = true;
    }

    public void stop()
    {
        enabled = false;
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = Vector2.zero;
    }

    public string getName()
    {
        return shipName;
    }

    public void isHit(float damage)
    {
        healthPoints -= damage;

        float perc = healthPoints / maxHealth;
        health.GetComponent<HealthBar>().setHealthPercentage(perc);

        if (healthPoints <= 0)
        {
            inactive = true;
            this.gameObject.GetComponent<SpriteRenderer>().
                color = Color.white;
            this.gameObject.
                GetComponent<Animator>().Play("Explode");
        }
    }

    public float getHealthPercent()
    {
        return (float)healthPoints / maxHealth;
    }

    public void setHealth(GameObject health)
    {
        this.health = health;
    }

    public void setTextObj(GameObject text)
    {
        this.text = text;
    }

    public void setText(string newText)
    {
        text.GetComponent<TextShip>().setText(newText);
    }

    public bool getActive()
    {
        return !inactive;
    }

    public void pause()
    {
        inactive = true;

        Rigidbody2D rbody = GetComponent<Rigidbody2D>(); 
        velKeep = rbody.velocity;
        rbody.velocity = Vector2.zero;

    }

    public void unpause()
    {
        inactive = false;

        Rigidbody2D rbody = GetComponent<Rigidbody2D>();
        rbody.velocity = velKeep;
    }
}
