using UnityEngine;
using System.Collections;

public class spawner : MonoBehaviour {
    public GameObject enemy;
    public GameObject ally;
    public GameObject player;
    public GameObject enemyCrown;
    public GameObject allyCrown;
    float cooldownMax = 15;
    float cooldown = 15;

    private Color enemyCol = new Color(1, 0.2f, 0.2f);
    private Color allyCol = new Color(0.2f, 1, 0.2f);
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (cooldown <= 0)
        {
            if (Input.GetButton("z"))
            {
                spawnAllyShip(new Vector2(ShipDefinitions.getCursor().x,
                    ShipDefinitions.getCursor().y));
            }
            if (Input.GetButton("x"))
            {
                spawnAllyCrown(new Vector2(ShipDefinitions.getCursor().x,
                    ShipDefinitions.getCursor().y));
            }
            if (Input.GetButton("c"))
            {
                spawnEnemyShip(new Vector2(ShipDefinitions.getCursor().x,
                    ShipDefinitions.getCursor().y));
            }
            if (Input.GetButton("v"))
            {
                spawnEnemyCrown(new Vector2(ShipDefinitions.getCursor().x,
                    ShipDefinitions.getCursor().y));
            }
            if(Input.GetButton("b"))
            {
                for (int i = 0; i <= 8; i++)
                {
                    Vector3 spawnPoint;
                    Vector3 spawnRand = 2*Random.insideUnitSphere;
                    spawnPoint = Vector3.zero;
                    spawnPoint.y = Camera.main.ScreenToWorldPoint(new Vector3(0, Camera.main.pixelHeight / 2)).y;
                    spawnRand.z = 0;
                    float z = Random.Range(0, 10);
                    if (z <= 5)
                    {
                        spawnPoint.x = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth / 4, 0, Camera.main.nearClipPlane)).x;
                    }
                    else
                    {
                        spawnPoint.x = Camera.main.ScreenToWorldPoint(new Vector3(3 * Camera.main.pixelWidth / 4, Camera.main.nearClipPlane)).x;
                    }

                    if (z <= 2.5)
                        spawnEnemyCrown(spawnPoint + spawnRand);
                    else if (z > 2.5 && z <= 5)
                        spawnEnemyShip(spawnPoint + spawnRand);
                    else if (z > 5 && z <= 7.5)
                        spawnAllyCrown(spawnPoint + spawnRand);
                    else
                        spawnAllyShip(spawnPoint + spawnRand);
                }
            }
            foreach (Touch touch in Input.touches)
            {
                Vector3 vec = Camera.main.ScreenToWorldPoint(touch.position);
                //Vector3 bound = Camera.main.
                //    ScreenToWorldPoint(new Vector3(Screen.width,
                //    Screen.height, 0));
                if (touch.phase == TouchPhase.Began)
                {
                    if(vec.x < 0)
                    {
                        GameObject obj;
                        if (vec.y < 0)
                        {
                            spawnEnemyShip(new Vector3(vec.x, vec.y));
                        }
                        else
                        {
                            spawnEnemyCrown(new Vector3(vec.x, vec.y));
                        }
                    }
                    else
                    {
                        if (vec.y < 0)
                        {
                            spawnAllyShip(new Vector3(vec.x, vec.y));
                        }
                        else
                        {
                            spawnAllyCrown(new Vector3(vec.x, vec.y));
                        }
                    }

                    if(touch.position.x < Screen.width / 10 &&
                        touch.position.y < Screen.height / 10)
                    {
                        foreach (ImplMainShip ship in GameObject.FindObjectsOfType<ImplMainShip>())
                        {
                            Destroy(ship.gameObject);
                        }
                        foreach (ImplCrownShip ship in GameObject.FindObjectsOfType<ImplCrownShip>())
                        {
                            Destroy(ship.gameObject);
                        }
                    }
                    if (touch.position.x > Screen.width * 0.9 &&
    touch.position.y > Screen.height * 0.9)
                    {
                        for (int i = 0; i <= 8; i++)
                        {
                            Vector3 spawnPoint;
                            Vector3 spawnRand = 2 * Random.insideUnitSphere;
                            spawnPoint = Vector3.zero;
                            spawnPoint.y = Camera.main.ScreenToWorldPoint(new Vector3(0, Camera.main.pixelHeight / 2)).y;
                            spawnRand.z = 0;
                            float z = Random.Range(0, 10);
                            if (z <= 5)
                            {
                                spawnPoint.x = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth / 4, 0, Camera.main.nearClipPlane)).x;
                            }
                            else
                            {
                                spawnPoint.x = Camera.main.ScreenToWorldPoint(new Vector3(3 * Camera.main.pixelWidth / 4, Camera.main.nearClipPlane)).x;
                            }

                            if (z <= 2.5)
                                spawnEnemyCrown(spawnPoint + spawnRand);
                            else if (z > 2.5 && z <= 5)
                                spawnEnemyShip(spawnPoint + spawnRand);
                            else if (z > 5 && z <= 7.5)
                                spawnAllyCrown(spawnPoint + spawnRand);
                            else
                                spawnAllyShip(spawnPoint + spawnRand);
                        }
                    }
                }
            }
        } else
        {
            cooldown--;
        }
    }

    void spawnAllyShip(Vector2 spawnPoint)
    {
        spawnShip(spawnPoint, ally, allyCol);
    }

    void spawnAllyCrown(Vector2 spawnPoint)
    {
        spawnShip(spawnPoint, allyCrown, allyCol);
    }

    void spawnEnemyShip(Vector2 spawnPoint)
    {
        spawnShip(spawnPoint, enemy, enemyCol);
    }

    void spawnEnemyCrown(Vector2 spawnPoint)
    {
        spawnShip(spawnPoint, enemyCrown, enemyCol);
    }

    void spawnShip(Vector2 spawnPoint, GameObject ship, Color color)
    {
        GameObject obj = (GameObject)Instantiate(ship, spawnPoint, Quaternion.Euler(0, 0, 0));
        obj.GetComponent<SpriteRenderer>().color = color;
        cooldown = cooldownMax;
    }

}
