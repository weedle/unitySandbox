using UnityEngine;
using System.Collections;

public class ImplMainShip : MonoBehaviour, IntfShip {
    public int rotationSpeed = 5;
    public float moveSpeed = 1;

    // Use this for initialization
    void Start () {
        rotationSpeed += Random.Range(-2, 2);
        moveSpeed += Random.Range(-0.3f, 0.3f);
        //Camera camera = Camera.main;
        //camera.orthographicSize = 640 / Screen.width * Screen.height / 2;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 temp;
        float vertExtent = Camera.main.orthographicSize;
        float horzExtent = vertExtent * Screen.width / Screen.height;

        float xbound = horzExtent * 0.9f;// 0.9f * Screen.width / 2; //8
        float ybound = vertExtent * 0.9f;// 0.9f * Screen.height / 2; //5
        if (transform.position.x < -xbound)
        {
            temp = new Vector3(xbound, transform.position.y, transform.position.z);
            transform.position = temp;
        }
        if (transform.position.x > xbound)
        {
            temp = new Vector3(-xbound, transform.position.y, transform.position.z);
            transform.position = temp;
        }
        if (transform.position.y > ybound)
        {
            temp = new Vector3(transform.position.x, -ybound, transform.position.z);
            transform.position = temp;
        }
        if (transform.position.y < -ybound)
        {
            temp = new Vector3(transform.position.x, ybound, transform.position.z);
            transform.position = temp;
        }
        temp = Vector3.zero;
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
}
