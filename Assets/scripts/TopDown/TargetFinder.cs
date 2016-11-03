using UnityEngine;
using System.Collections;
using System;

public class TargetFinder : MonoBehaviour {

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
    public GameObject getTarget(ShipDefinitions.Faction faction)
    {
        if (faction == ShipDefinitions.Faction.Enemy)
        {
            string[] tags = { "Player", "PlayerAffil" };
            GameObject obj = GetClosestObject(tags);
            if (obj)
                return obj;
        }
        else if (faction == ShipDefinitions.Faction.PlayerAffil)
        {
            string[] tags = { "Enemy" };
            GameObject obj = GetClosestObject(tags);
            if (obj)
                return obj;
        }
        return null;
    }
}
