using UnityEngine;
using System.Collections;

public interface IntfShipController
{
    void getNextState();

    void isHit(float damage);

    ShipDefinitions.Faction getFaction();

    void setFaction(ShipDefinitions.Faction faction);
}
