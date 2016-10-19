using UnityEngine;
using System.Collections;

public interface IntfShipController
{
    void getNextState();

    void isHit();

    ShipDefinitions.Faction getFaction();
}
