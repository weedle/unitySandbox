using UnityEngine;
using System.Collections;
using System;

public class ImplMainShipController : MonoBehaviour, IntfShipController
{
    public IntfShip ship;
    public float healthPoints = 100;
    private ShipDefinitions.Faction faction;

    // does nothing since player targets manually
    public GameObject getTarget()
    {
        return null;
    }

    public void getNextState()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        if (vertical != 0)
            ship.move(vertical);
        if (horizontal != 0)
            ship.rotate(horizontal);
        if (Input.GetButton("Fire1"))
            ship.fire();
        if (Input.GetButton("Fire2"))
            ship.brake();
    }

    // Use this for initialization
    void Start ()
    {
        faction = ShipDefinitions.stringToFaction(gameObject.tag);
        ship = GetComponent<IntfShip>();
	}
	
	// Update is called once per frame
	void Update () {
        getNextState();
    }

    public void isHit(float damage)
    {
        healthPoints -= damage;
        print("Current Health: " + healthPoints.ToString());
        if (healthPoints >= 0)
            Destroy(gameObject);
    }

    public ShipDefinitions.Faction getFaction()
    {
        return faction;
    }

    public void setFaction(ShipDefinitions.Faction faction)
    {
        this.faction = faction;
    }
}
