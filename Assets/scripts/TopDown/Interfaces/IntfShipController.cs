using UnityEngine;
using System.Collections;

public interface IntfShipController
{
    void getNextState();

    void isHit(float damage);

    ShipDefinitions.Faction getFaction();

    string getName();

    void setFaction(ShipDefinitions.Faction faction);

    void setHealth(GameObject health);

    void setText(GameObject text);
}
