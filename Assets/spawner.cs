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
        } else
        {
            cooldown--;
        }
    }
}
