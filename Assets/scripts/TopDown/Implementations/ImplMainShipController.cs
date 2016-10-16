using UnityEngine;
using System.Collections;
using System;

public class ImplMainShipController : MonoBehaviour, IntfShipController
{
    public IntfShip ship;

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
    void Start () {
        ship = GetComponent<IntfShip>();
	}
	
	// Update is called once per frame
	void Update () {
        getNextState();
    }
}
