using UnityEngine;
using System.Collections;
using System;

public class ImplEnemyShipController : MonoBehaviour, IntfShipController
{
    public IntfShip ship;
    public GameObject health;
    public GameObject text;
    public float healthPoints = 10;
    public float maxHealth = 10;
    public bool inactive;
    private string tagReserve;
    private ShipDefinitions.Faction faction;

    public void getNextState()
    {
        Vector3 target = Vector3.zero;
        GameObject obj = GetComponent<TargetFinder>().getTarget(faction);
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

        if (ShipDefinitions.quickestRotation(shipAngle, targetAngle))
            ship.rotate(0.5f);
        else
            ship.rotate(-0.5f);

        
        ship.move(1);

        IntfShip shipObject = GetComponent<IntfShip>();
        if ((shipAngle + shipObject.getEffectiveAngle() > targetAngle &&
            shipAngle - shipObject.getEffectiveAngle() < targetAngle) &&
                (Vector3.Distance(transform.position,
                    target) < shipObject.getEffectiveDistance()))
            ship.fire();
        shipObject = null;
        obj = null;
    }

    // Use this for initialization
    void Start()
    {
        faction = ShipDefinitions.stringToFaction(gameObject.tag);
        ship = this.GetComponent<IntfShip>();
        tag = gameObject.tag;
        tagReserve = tag;
    }

    // Update is called once per frame
    void Update()
    {
        if (inactive) return;
        getNextState();
    }

    public void isHit(float damage)
    {
        healthPoints -= damage;

        float perc = healthPoints / maxHealth;
        health.GetComponent<HealthBar>().setHealthPercentage(perc);

        if (healthPoints <= 0)
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

    public void setFaction(ShipDefinitions.Faction faction)
    {
        this.faction = faction;
    }

    public void enable()
    {
        gameObject.tag = tagReserve;
        enabled = true;
        ship.start();
    }

    public void disable()
    {
        tagReserve = gameObject.tag;
        gameObject.tag = "Untagged";
        enabled = false;
        ship.stop();
    }

    void OnMouseDown()
    {
        if (enabled) disable();
        else enable();
    }

    public void setHealth(GameObject health)
    {
        this.health = health;
    }

    public void setText(GameObject text)
    {
        this.text = text;
    }
}
