using UnityEngine;
using System.Collections;

public class ImplCrownFiringModule : MonoBehaviour, IntfFiringModule
{
    public Color color1 = Color.blue;
    public Color color2 = Color.cyan;
    public int counter = 0;
    public int ammoMax = 10;
    public int ammunition = 10;
    public int ammoCooldown = 100;

    // Use this for initialization
    void Start ()
    {
        ammoMax += Random.Range(-4, 4);
        ammoCooldown += Random.Range(-20, 20);
    }
	
	// Update is called once per frame
	void Update () {
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
        GameObject target = GetComponent<TargetFinder>().getTarget();
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = Vector3.zero;
        if (ammunition > 0)
        {
            Vector3 firePoint = transform.position;
            ShipDefinitions.DrawLine(firePoint, target.transform.position, color1, 0.1f);
            ShipDefinitions.DrawLine(firePoint, target.transform.position, color2, 0.12f);
            ShipDefinitions.DrawLine(firePoint, target.transform.position, color1, 0.14f);
            ShipDefinitions.DrawLine(firePoint, target.transform.position, color2, 0.1f);
            target.GetComponent<IntfShipController>().isHit();
            ammunition--;
        }
    }
}
