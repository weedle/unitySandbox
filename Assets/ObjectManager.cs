using UnityEngine;
using System.Collections;

// You can save a lot of resources by avoiding instantiating
// when necessary, and just cleverly hiding/reappearing objects
// to simulate instantiation instead

// Here we're going to try that to address performance issues
// we're running into on Android
public class ObjectManager : MonoBehaviour
{
    public GameObject fireShip;
    public GameObject crownShip;
    public GameObject missileShip;
    public GameObject healerShip;

    private GameObject[] FireShips;
    private GameObject[] CrownShips;
    private GameObject[] MissileShips;
    private GameObject[] HealShips;

    private GameObject[] Fire;
    private GameObject[] Missile;

    private int numFireShips = 0;
    private int numCrownShips = 0;
    private int numMissileShips = 0;
    private int numHealShips = 0;

    private const int maxShips = 10;
    private const int maxProjectiles = 20;

	// Use this for initialization
	void Start () {
        FireShips = new GameObject[maxShips];
        CrownShips = new GameObject[maxShips];
        MissileShips = new GameObject[maxShips];
        HealShips = new GameObject[maxShips];

        Fire = new GameObject[maxProjectiles];
        Missile = new GameObject[maxProjectiles];
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public GameObject getObject(System.Type type, Vector2 spawnPoint)
    {
        GameObject obj = null;

        if (type.Equals(typeof(ImplFlamethrowerFiringModule)))
            return getFireShip(spawnPoint);

            return obj;
    }

    public GameObject getFireShip(Vector2 spawnPoint)
    {
        GameObject obj = null;
        if(numFireShips < maxShips)
        {
            obj = (GameObject)Instantiate(fireShip, spawnPoint, Quaternion.Euler(0, 0, 0));
            FireShips[numFireShips] = obj;
            numFireShips++;
        }
        else
        {
            numFireShips--;
            obj = FireShips[numFireShips];
        }
        return obj;
    }

    public void removeFireShip()
    {

    }
}
