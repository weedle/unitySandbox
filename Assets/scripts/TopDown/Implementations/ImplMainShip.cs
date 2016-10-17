using UnityEngine;
using System.Collections;

public class ImplMainShip : MonoBehaviour, IntfShip {
    public Rigidbody2D projectile;
    private float PROJECTILESPEED = 5;
    public int ammoMax = 10;
    public int ammunition = 10;
    public int ammoCooldown = 50;
    public int counter = 0;

    // Use this for initialization
    void Start () {
        projectile.GetComponent<ParticleAbstract>().
            setFaction(gameObject.GetComponent<IntfShipController>().getFaction());
	}
	
	// Update is called once per frame
	void Update () {

        counter++;
        if(counter >= ammoCooldown)
        {
            if (ammunition < ammoMax)
            {
                ammunition++;
                counter = 0;
            }
        }


        float xbound = 5f;
        float ybound = 3.5f;
        if(transform.position.x < -xbound)
            transform.position = 
                new Vector3(xbound, transform.position.y, transform.position.z);

        if (transform.position.x > xbound)
            transform.position =
                new Vector3(-xbound, transform.position.y, transform.position.z);

        if (transform.position.y > ybound)
            transform.position =
                new Vector3(transform.position.x, -ybound, transform.position.z);

        if (transform.position.y < -ybound)
            transform.position =
                new Vector3(transform.position.x, ybound, transform.position.z);
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
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        if(vertical != 0)
            rigidbody.velocity = new Vector2(Mathf.Cos(getAngle()), 
                Mathf.Sin(getAngle())) * 1.5f * (vertical + Mathf.Sign(vertical));
    }

    public void rotate(float horizontal)
    {
        if(horizontal != 0)
            transform.Rotate(new Vector3(0, 0, -5 * horizontal));
    }


    public void fire()
    {
        if (ammunition > 0)
        {
            Vector3 vec;
            Rigidbody2D proj;
            vec = new Vector3(0, (float)0.75, 0);
            vec = transform.rotation * vec;
            proj = (Rigidbody2D)Instantiate(projectile, new Vector3(transform.position.x, transform.position.y) + vec, Quaternion.Euler(0, 0, 90));
            proj.velocity = new Vector3(PROJECTILESPEED * vec.x, PROJECTILESPEED * vec.y, 0);
            ammunition--;
        }
    }
}
