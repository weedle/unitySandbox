using UnityEngine;
using System.Collections;
using System;

public class ImplEnemyShipController : MonoBehaviour, IntfShipController
{
    public IntfShip ship;
    public float healthPoints = 10;
    Boolean inactive = false;
    public ShipDefinitions.Faction faction = ShipDefinitions.Faction.Enemy;

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
        Vector3 target = Vector3.zero;
        GameObject obj = GetComponent<TargetFinder>().getTarget();
        if(obj) target = obj.transform.position;
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
        if ((shipAngle + 4 > targetAngle &&
            shipAngle - 4 < targetAngle) &&
                (Vector3.Distance(transform.position,
                    target) < 3))
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
        healthPoints--;
        if (healthPoints == 0)
        {
            inactive = true;
            this.gameObject.GetComponent<SpriteRenderer>().
                color = Color.white;
            this.gameObject.
                GetComponent<Animator>().Play("Explode");
        }
    }

    public ShipDefinitions.Faction getFaction()
    {
        return faction;
    }
}
