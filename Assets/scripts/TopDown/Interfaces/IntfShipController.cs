using UnityEngine;
using System.Collections;

public interface IntfShipController
{
    GameObject getTarget();

    void getNextState();

    void isHit();

    ShipDefinitions.Faction getFaction();
}
