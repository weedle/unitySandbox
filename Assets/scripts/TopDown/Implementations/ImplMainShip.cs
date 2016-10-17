using UnityEngine;
using System.Collections;

public class ImplMainShip : MonoBehaviour, IntfShip {
    public Rigidbody2D projectile;
    private float PROJECTILESPEED = 15;
    public int ammoMax = 10;
    public int ammunition = 10;
    public int ammoCooldown = 50;
    public int counter = 0;
    private int rotationSpeed = 5;
    private float moveSpeed = 1.5f;

    // Use this for initialization
    void Start () {
        PROJECTILESPEED += Random.Range(-4, 4);
        rotationSpeed += Random.Range(-2, 2);
        ammoMax += Random.Range(-4, 4);
        ammoCooldown += Random.Range(-20, 20);
        moveSpeed += Random.Range(-0.3f, 0.3f);
        Camera camera = gameObject.GetComponent<Camera>();
        //camera.orthographicSize = 640 / Screen.width * Screen.height / 2;
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


        float xbound = 8;//0.8f * Screen.width / 2;
        float ybound = 5;//0.8f * Screen.height / 2;
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
                Mathf.Sin(getAngle())) * moveSpeed * (vertical + Mathf.Sign(vertical));
    }

    public void rotate(float horizontal)
    {
        if(horizontal != 0)
            transform.Rotate(new Vector3(0, 0, -1 * rotationSpeed * horizontal));
    }


    public void fire()
    {
        if (ammunition > 0)
        {
            Vector3 vec;
            Rigidbody2D proj;
            vec = new Vector3(0, (float)0.25, 0);
            vec = transform.rotation * vec;
            proj = (Rigidbody2D)Instantiate(projectile, new Vector3(transform.position.x, transform.position.y) + vec, Quaternion.Euler(0, 0, 90));
            proj.velocity = new Vector3(PROJECTILESPEED * vec.x, PROJECTILESPEED * vec.y, 0);
            ammunition--;
        }
    }
}
