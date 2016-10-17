using UnityEngine;
using System.Collections;

public class spawner : MonoBehaviour {
    public GameObject enemy;
    public GameObject friend;
    public GameObject player;
    float cooldownMax = 50;
    float cooldown = 50;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (cooldown <= 0)
        {
            if (Input.GetButton("z"))
            {
                Instantiate(enemy, new Vector3(transform.position.x, transform.position.y), Quaternion.Euler(0, 0, 0));
                cooldown = cooldownMax;
            }
            if (Input.GetButton("x"))
            {
                Instantiate(friend, new Vector3(transform.position.x, transform.position.y), Quaternion.Euler(0, 0, 0));
                cooldown = cooldownMax;
            }
            if (Input.GetButton("c"))
            {
                Instantiate(player, new Vector3(transform.position.x, transform.position.y), Quaternion.Euler(0, 0, 0));
                cooldown = cooldownMax;
            }
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    if(touch.position.x < Screen.width / 2)
                    {
                        Instantiate(enemy, new Vector3(transform.position.x, transform.position.y), Quaternion.Euler(0, 0, 0));
                        cooldown = cooldownMax;
                    }
                    else
                    {
                        Instantiate(friend, new Vector3(transform.position.x, transform.position.y), Quaternion.Euler(0, 0, 0));
                        cooldown = cooldownMax;
                    }

                    if(touch.position.x < Screen.width / 20 &&
                        touch.position.y < Screen.height / 20)
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
