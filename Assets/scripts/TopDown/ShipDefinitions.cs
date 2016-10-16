using UnityEngine;
using System;

// Contains various definitions that will be useful for other scripts
public class ShipDefinitions
{

    // SHIP DEFINITIONS

    public enum SState
    {
        Inactive, Searching, Aiming, Firing, Cooling
    }

    // General rules for interactions between Factions
    // Player and PlayerAffil will target Enemy and Rogue
    // Enemy will target Player and PlayerAffil
    // Rogue will fire on all targets except possibly other Rogues
    // Indep will fire on no targets unless fired upon
    // Relationships are entity-dependent, and can be dynamically
    // assigned during gameplay
    public enum Faction
    {
        Player, PlayerAffil, Enemy, Rogue, Indep
    }

    public static Vector3 getCursor()
    {
        Vector3 v3 = Input.mousePosition;
        v3.z = -Camera.main.transform.position.z;
        v3 = Camera.main.ScreenToWorldPoint(v3);

        return v3;
    }
}
