using UnityEngine;
using System.Collections;

public class ImplCrownFiringModule : MonoBehaviour, IntfFiringModule
{
    public Color color1 = Color.blue;
    public Color color2 = Color.cyan;
    private ShipDefinitions.Faction faction;
    public int counter = 0;
    public int ammoMax = 15;
    public int ammunition = 15;
    public int ammoCooldown = 120;

    // Use this for initialization
    void Start ()
    {
        faction = ShipDefinitions.stringToFaction(gameObject.tag);
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
        GameObject target = GetComponent<TargetFinder>().getTarget(faction);
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = Vector3.zero;

        if(target == null)
        {
            return;
        }

        if(Vector3.Distance(transform.position,target.transform.position) > getEffectiveDistance())
        {
            return;
        }

        if (ammunition > 0)
        {
            Vector3 firePoint = transform.position;
            ShipDefinitions.DrawLine(firePoint, target.transform.position, color1, 0.1f);
            ShipDefinitions.DrawLine(firePoint, target.transform.position, color2, 0.12f);
            ShipDefinitions.DrawLine(firePoint, target.transform.position, color1, 0.14f);
            ShipDefinitions.DrawLine(firePoint, target.transform.position, color2, 0.1f);
            target.GetComponent<IntfShipController>().isHit(2);
            ammunition--;
        }
        target = null;
    }

    public float getEffectiveDistance()
    {
        return 3;
    }

    public float getEffectiveAngle()
    {
        return 8;
    }

    public bool canFire()
    {
        if (ammunition > 0) return true;
        else return false;
    }
}
