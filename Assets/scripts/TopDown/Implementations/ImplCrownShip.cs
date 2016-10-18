using UnityEngine;
using System.Collections;

public class ImplCrownShip : MonoBehaviour, IntfShip
{
    public int ammoMax = 10;
    public int ammunition = 10;
    public int ammoCooldown = 200;
    public int counter = 0;
    private int rotationSpeed = 5;
    private float moveSpeed = 1;
    public Color color1 = Color.blue;
    public Color color2 = Color.cyan;

    // Use this for initialization
    void Start()
    {
        rotationSpeed += Random.Range(-2, 2);
        ammoMax += Random.Range(-4, 4);
        ammoCooldown += Random.Range(-20, 20);
        moveSpeed += Random.Range(-0.3f, 0.3f);
    }

    // Update is called once per frame
    void Update()
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

        float vertExtent = Camera.main.orthographicSize;
        float horzExtent = vertExtent * Screen.width / Screen.height;

        float xbound = horzExtent * 0.9f;// 0.9f * Screen.width / 2; //8
        float ybound = vertExtent * 0.9f;// 0.9f * Screen.height / 2; //5
        if (transform.position.x < -xbound)
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
        if (vertical != 0)
            rigidbody.velocity = new Vector2(Mathf.Cos(getAngle()),
                Mathf.Sin(getAngle())) * moveSpeed * (vertical + Mathf.Sign(vertical));
    }

    public void rotate(float horizontal)
    {
        if (horizontal != 0)
            transform.Rotate(new Vector3(0, 0, -1 * rotationSpeed * horizontal));
    }


    public void fire()
    {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = Vector3.zero;
        if (ammunition > 0)
        {
            GameObject target = gameObject.
                GetComponent<IntfShipController>().getTarget();
            Vector3 firePoint = transform.position;
            ShipDefinitions.DrawLine(firePoint, target.transform.position, color1, 0.1f);
            ShipDefinitions.DrawLine(firePoint, target.transform.position, color2, 0.12f);
            ShipDefinitions.DrawLine(firePoint, target.transform.position, color1, 0.14f);
            ShipDefinitions.DrawLine(firePoint, target.transform.position, color2, 0.1f);
            target.GetComponent<IntfShipController>().isHit();
            ammunition--;
        }
    }

    public float getProjectileSpeed()
    {
        return 0;
    }
}
