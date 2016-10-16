using UnityEngine;
using System.Collections;

public class ImplMainShip : MonoBehaviour, IntfShip {
    public Rigidbody projectile;
    private float PROJECTILESPEED = 5;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
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
                Mathf.Sin(getAngle())) * 2 * Mathf.Sign(vertical);
        float horizontal = Input.GetAxis("Horizontal");
    }

    public void rotate(float horizontal)
    {
        if(horizontal != 0)
            transform.Rotate(new Vector3(0, 0, -5 * horizontal));
    }


    public void fire()
    {
        Vector3 vec;
        Rigidbody proj;
        vec = new Vector3(0, (float)0.75, 0);
        vec = transform.rotation * vec;
        proj = (Rigidbody)Instantiate(projectile, new Vector3(transform.position.x, transform.position.y) + vec, Quaternion.Euler(0, 0, 90));
        proj.velocity = new Vector3(PROJECTILESPEED * vec.x, PROJECTILESPEED * vec.y, 0);
    }
}
