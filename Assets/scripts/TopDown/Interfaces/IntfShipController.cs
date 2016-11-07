using UnityEngine;
using System.Collections;

public interface IntfShipController
{
    void getNextState();

    ShipDefinitions.Faction getFaction();

    void setFaction(ShipDefinitions.Faction faction);

    string getName();

    ShipDefinitions.SState getState();

    void pause();

    void unpause();
}
