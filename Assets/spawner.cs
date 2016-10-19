using UnityEngine;
using System.Collections;

public class spawner : MonoBehaviour {
    public GameObject enemy;
    public GameObject ally;
    public GameObject player;
    public GameObject crownEnemy;
    public GameObject crownAlly;
    float cooldownMax = 30;
    float cooldown = 30;

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
                GameObject obj = (GameObject) Instantiate(enemy, new Vector3(ShipDefinitions.getCursor().x,
                    ShipDefinitions.getCursor().y), Quaternion.Euler(0, 0, 0));
                obj.GetComponent<SpriteRenderer>().color = enemyCol;
                cooldown = cooldownMax;
            }
            if (Input.GetButton("x"))
            {
                GameObject obj = (GameObject) Instantiate(ally, new Vector3(ShipDefinitions.getCursor().x,
                    ShipDefinitions.getCursor().y), Quaternion.Euler(0, 0, 0));
                obj.GetComponent<SpriteRenderer>().color = allyCol;
                cooldown = cooldownMax;
            }
            if (Input.GetButton("c"))
            {
                GameObject obj = (GameObject)Instantiate(crownEnemy, new Vector3(ShipDefinitions.getCursor().x,
                    ShipDefinitions.getCursor().y), Quaternion.Euler(0, 0, 0));
                obj.GetComponent<SpriteRenderer>().color = enemyCol;
                cooldown = cooldownMax;
            }
            if (Input.GetButton("v"))
            {
                GameObject obj = (GameObject)Instantiate(crownAlly, new Vector3(ShipDefinitions.getCursor().x,
                    ShipDefinitions.getCursor().y), Quaternion.Euler(0, 0, 0));
                obj.GetComponent<SpriteRenderer>().color = allyCol;
                cooldown = cooldownMax;
            }
            foreach (Touch touch in Input.touches)
            {
                Vector3 vec = Camera.main.ScreenToWorldPoint(touch.position);
                Vector3 bound = Camera.main.
                    ScreenToWorldPoint(new Vector3(Screen.width,
                    Screen.height, 0));
                if (touch.phase == TouchPhase.Began)
                {
                    if(vec.x < 0)
                    {
                        GameObject obj;
                        if (vec.y < 0)
                        {
                            obj = (GameObject)Instantiate(enemy, new Vector3(vec.x, vec.y), Quaternion.Euler(0, 0, 0));
                        }
                        else
                        {
                            obj = (GameObject)Instantiate(crownEnemy, new Vector3(vec.x, vec.y), Quaternion.Euler(0, 0, 0));
                        }
                        obj.GetComponent<SpriteRenderer>().color = enemyCol;
                        cooldown = cooldownMax;
                    }
                    else
                    {
                        GameObject obj;
                        if (vec.y < 0)
                        {
                            obj = (GameObject)Instantiate(ally, new Vector3(vec.x, vec.y), Quaternion.Euler(0, 0, 0));
                        }
                        else
                        {
                            obj = (GameObject)Instantiate(crownAlly, new Vector3(vec.x, vec.y), Quaternion.Euler(0, 0, 0));
                        }
                        obj.GetComponent<SpriteRenderer>().color = allyCol;
                        cooldown = cooldownMax;
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
                    /*
                    if (touch.position.x > Screen.width * 0.9 &&
    touch.position.y > Screen.height * 0.9)
                    {
                        for(int i = 0; i <= 8; i++)
                        {
                            Color color;
                            GameObject obj;
                            Vector3 spawnPoint;
                            Vector3 spawnRand = Vector3.zero;// Random.insideUnitSphere;
                            spawnRand.z = 0;
                            float z = Random.Range(1, 10);
                            if (z <= 5) {
                                color = enemyCol; 
                                spawnPoint = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width/4, Screen.height/2)) + spawnRand;
                            }
                            else
                            {
                                color = allyCol;
                                spawnPoint = Camera.main.ScreenToWorldPoint(new Vector2(3 * Screen.width / 4, Screen.height / 2)) + spawnRand;
                            }

                            if(z <= 2.5)
                                obj = (GameObject)Instantiate(crownEnemy, spawnPoint, Quaternion.Euler(0, 0, 0));
                            else if( z > 2.5 && z <= 5)
                                obj = (GameObject)Instantiate(enemy, spawnPoint, Quaternion.Euler(0, 0, 0));
                            else if (z > 5 && z <= 7.5)
                                obj = (GameObject)Instantiate(crownAlly, spawnPoint, Quaternion.Euler(0, 0, 0));
                            else
                                obj = (GameObject)Instantiate(ally, spawnPoint, Quaternion.Euler(0, 0, 0));
                            obj.GetComponent<SpriteRenderer>().color = color;
                        }
                    }
                    */
                }
            }
        } else
        {
            cooldown--;
        }
    }
}
