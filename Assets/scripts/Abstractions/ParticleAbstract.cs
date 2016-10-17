using UnityEngine;
using System.Collections;

public abstract class ParticleAbstract : MonoBehaviour {
    public int lifetime;
    public ShipDefinitions.Faction faction;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	    if( lifetime <= 0 )
        {
            Destroy(gameObject);
        } else
        {
            lifetime--;
        }
	}

    public void setFaction(ShipDefinitions.Faction faction)
    {
        this.faction = faction;
    }
}
