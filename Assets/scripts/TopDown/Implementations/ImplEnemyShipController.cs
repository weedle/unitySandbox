using UnityEngine;
using System.Collections;
using System;

public class ImplEnemyShipController : MonoBehaviour, IntfShipController
{
    public IntfShip ship;
    private GameObject GetClosestObject(String tag)
    {
        GameObject[] list = GameObject.FindGameObjectsWithTag(tag);

        GameObject closest = null;

        foreach( GameObject obj in list )
        {
            if (closest == null) closest = obj;

            if (Vector3.Distance(transform.position, obj.transform.position) <= 
                Vector3.Distance(transform.position, closest.transform.position))
            {
                closest = obj;
            }
        }

        return closest;
    }
    public Vector3 getTarget()
    {
        return GetClosestObject("Player").transform.position;
    }

    // find quickest path for thing at angle1 to reach angle2
    // if true, turn clockwise, otherwise turn counterclockwise
    public bool quickestRotation(float angle1, float angle2)
    {
        if (angle1 > 180)
        {
            if (angle2 > angle1 ||
                (angle2 < angle1 - 180))
                return false;
            else
                return true;
        }
        else
        {
            if (angle2 > angle1 &&
                (angle2 < angle1 + 180))
                return false;
            else
                return true;
        }
    }

    public void getNextState()
    {
        Vector3 diff = getTarget() - transform.position;

        float targetAngle = Mathf.Atan(diff.y / diff.x) * 180 / Mathf.PI + 90;

        if (diff.x > 0)
            targetAngle = 180 + targetAngle;
        targetAngle = (int)targetAngle;

        float shipAngle = transform.rotation.eulerAngles.z;

        print("Target: " + targetAngle.ToString() + " Ship: " + shipAngle.ToString());

        if (quickestRotation(shipAngle, targetAngle))
            ship.rotate(0.5f);
        else
            ship.rotate(-0.5f);

        ship.move(0.75f);
        if (shipAngle + 2 > targetAngle &&
            shipAngle - 2 < targetAngle)
            ship.fire();

    }

    // Use this for initialization
    void Start()
    {
        ship = GetComponent<IntfShip>();
    }

    // Update is called once per frame
    void Update()
    {
        getNextState();
    }
}
