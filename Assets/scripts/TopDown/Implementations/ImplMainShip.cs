using UnityEngine;
using System.Collections;

public class ImplMainShip : MonoBehaviour, IntfShip {
    private int rotationSpeed = 5;
    private float moveSpeed = 1;

    // Use this for initialization
    void Start () {
        rotationSpeed += Random.Range(-2, 2);
        moveSpeed += Random.Range(-0.3f, 0.3f);
        //Camera camera = Camera.main;
        //camera.orthographicSize = 640 / Screen.width * Screen.height / 2;
	}
	
	// Update is called once per frame
	void Update () {

        float vertExtent = Camera.main.orthographicSize;
        float horzExtent = vertExtent * Screen.width / Screen.height;

        float xbound = horzExtent*0.9f;// 0.9f * Screen.width / 2; //8
        float ybound = vertExtent*0.9f;// 0.9f * Screen.height / 2; //5
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
        GetComponent<IntfFiringModule>().fire();
    }
}
