using UnityEngine;
using System.Collections;

public class shipScript : MonoBehaviour {
    public float PROJECTILESPEED;
    public object FIRINGCOOLDOWN;
    public Rigidbody projectile;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        if( vertical != 0 )
        {
            move();
        }

        if( horizontal != 0 )
        {
            rotate();
        }
        if (Input.GetButton("Fire1"))
        {
            fire();
        }

        if ( Input.GetButton("Fire2") )
        {
            brake();
        }
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

    public void move()
    {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        float vertical = Input.GetAxis("Vertical");
        rigidbody.velocity = new Vector2(Mathf.Cos(getAngle()), Mathf.Sin(getAngle())) * 2 * Mathf.Sign(vertical);
    }

    public void rotate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        transform.Rotate(new Vector3(0, 0, -5 * horizontal));
    }

    public void fire()
    {
            Vector3 vec;
            Rigidbody proj;
            vec = new Vector3(0, (float) 0.75, 0);
            vec = transform.rotation * vec;
            proj = (Rigidbody)Instantiate(projectile, new Vector3(transform.position.x, transform.position.y) + vec, Quaternion.Euler(0, 0, 90));
            proj.velocity = new Vector3(PROJECTILESPEED * vec.x, PROJECTILESPEED * vec.y, 0);
            //cooldown = FIRINGCOOLDOWN;
    }
}
