using UnityEngine;
using System.Collections;
using System;

public class ImplEnemyShipController : MonoBehaviour, IntfShipController
{
    public IntfShip ship;
    public float healthPoints = 10;
    Boolean inactive = false;
    public ShipDefinitions.Faction faction = ShipDefinitions.Faction.Enemy;

    private GameObject GetClosestObject(String[] tags)
    {
        GameObject closest = null;
        foreach (String tag in tags)
        {
            GameObject[] list = GameObject.FindGameObjectsWithTag(tag);

            foreach (GameObject obj in list)
            {
                if (closest == null) closest = obj;

                if (Vector3.Distance(transform.position, obj.transform.position) <=
                    Vector3.Distance(transform.position, closest.transform.position))
                {
                    closest = obj;
                }
            }
        }
        return closest;
    }
    public Vector3 getTarget()
    {
        if(faction == ShipDefinitions.Faction.Enemy)
        {
            string[] tags = { "Player", "PlayerAffil" };
            GameObject obj = GetClosestObject(tags);
            if (obj)
                return obj.transform.position;
        }
        else if(faction == ShipDefinitions.Faction.PlayerAffil)
        {
            string[] tags = { "Enemy" };
            GameObject obj = GetClosestObject(tags);
            if (obj)
                return obj.transform.position;
        }
        return new Vector3(0,0,0);
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
        Vector3 target = getTarget();
        Vector3 diff = target - transform.position;
        if(diff == -transform.position)
        {
            ship.brake();
            return;
        }
        float targetAngle = Mathf.Atan(diff.y / diff.x) * 180 / Mathf.PI + 90;

        if (diff.x > 0)
            targetAngle = 180 + targetAngle;
        targetAngle = (int)targetAngle;

        float shipAngle = transform.rotation.eulerAngles.z;

        //print("Target: " + targetAngle.ToString() + " Ship: " + shipAngle.ToString());

        if (quickestRotation(shipAngle, targetAngle))
            ship.rotate(0.5f);
        else
            ship.rotate(-0.5f);

        
        ship.move(1);
        if (shipAngle + 2 > targetAngle &&
            shipAngle - 2 < targetAngle)
            ship.fire();

    }

    // Use this for initialization
    void Start()
    {
        ship = this.GetComponent<IntfShip>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inactive) return;
        getNextState();
    }

    public void isHit()
    {
        print("F: " + faction.ToString() + " " + healthPoints);
        healthPoints--;
        if (healthPoints == 0)
        {
            inactive = true;
            this.gameObject.
                GetComponent<Animator>().Play("Explode");
        }
    }

    public ShipDefinitions.Faction getFaction()
    {
        return faction;
    }
}
