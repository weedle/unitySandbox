using UnityEngine;
using System;

// Contains various definitions that will be useful for other scripts
public class ShipDefinitions
{
    static string[] names = new string[] {
        "Alice", "Bob", "Carol", "Daisy", "Eliza",
        "Francis", "Greg", "Harry", "Ingrid", "Jenne",
        "Jen", "Jo", "Kevin", "Letticia", "Morrigan",
        "Nancy", "Orpheus", "Penelope", "Quark", "Stephanie"};
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

    public static void DrawLine(Vector3 start, Vector3 end, Color color, float duration = 0.2f, float width = 0.075f)
    {
        GameObject myLine = new GameObject();
        myLine.transform.position = start;
        myLine.AddComponent<LineRenderer>();
        LineRenderer lr = myLine.GetComponent<LineRenderer>();
        lr.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
        lr.SetColors(color, color);
        lr.SetWidth(width, width);
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
        GameObject.Destroy(myLine, duration);
    }

    public static void DrawSquare(Vector3 bottomLeft, Vector3 topRight, Color color, float duration = 0.2f, float width = 0.075f)
    {
        Vector3 bottomRight = new Vector3(topRight.x, bottomLeft.y);
        Vector3 topLeft = new Vector3(bottomLeft.x, topRight.y);
        ShipDefinitions.DrawLine(bottomLeft, bottomRight, color, duration, width);
        ShipDefinitions.DrawLine(bottomLeft, topLeft, color, duration, width);
        ShipDefinitions.DrawLine(topRight, bottomRight, color, duration, width);
        ShipDefinitions.DrawLine(topRight, topLeft, color, duration, width);
    }

    // find quickest path for thing at angle1 to reach angle2
    // if true, turn clockwise, otherwise turn counterclockwise
    public static bool quickestRotation(float angle1, float angle2)
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

    public static Faction stringToFaction(String str)
    {
        switch(str)
        {
            case "Enemy":
                return Faction.Enemy;
            case "Indep":
                return Faction.Indep;
            case "Player":
                return Faction.Player;
            case "PlayerAffil":
                return Faction.PlayerAffil;
            case "Rogue":
                return Faction.Rogue;
            default:
                return Faction.Player;
        }
    }

    public static string generateName()
    {
        int x = (int) Math.Floor((double) UnityEngine.Random.Range(1, 3000));
        string prefix = names[(int) Math.Floor((double) UnityEngine.Random.Range(0, names.Length))];
        return prefix + x.ToString();
    }
}
