using UnityEngine;
using System.Collections;

public class spawner : MonoBehaviour {
    public GameObject enemy;
    public GameObject ally;
    public GameObject player;
    public GameObject crownEnemy;
    public GameObject crownAlly;
    float cooldownMax = 50;
    float cooldown = 50;

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
                    }
                }
            }
        } else
        {
            cooldown--;
        }
    }
}
