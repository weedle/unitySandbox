using UnityEngine;
using System.Collections;

public class ImplFlamethrowerFiringModule : MonoBehaviour, IntfFiringModule
{
    public int counter = 0;
    public Rigidbody2D projectile;
    public float projectileSpeed = 20;
    public int ammoMax = 15;
    public int ammunition = 15;
    public int ammoCooldown = 200;

    // Use this for initialization
    void Start ()
    {
        projectileSpeed += Random.Range(-4, 4);
        ammoMax += Random.Range(-4, 4);
        ammoCooldown += Random.Range(-20, 20);
        projectile.GetComponent<ParticleAbstract>().
            setFaction(gameObject.GetComponent<IntfShipController>().getFaction());
    }
	
	// Update is called once per frame
	void Update ()
    {
        counter++;
        if (counter >= ammoCooldown)
        {
            if (ammunition < ammoMax)
            {
                ammunition = ammoMax;
                counter = 0;
            }
        }
    }

    public void fire()
    {
        if (ammunition > 0)
        {
            Vector3 vec;
            Rigidbody2D proj;
            vec = new Vector3(0, (float)0.25, 0);
            vec = transform.rotation * vec;
            proj = (Rigidbody2D)Instantiate(projectile, new Vector3(transform.position.x, transform.position.y) + vec, Quaternion.Euler(0, 0, 90));
            proj.velocity = new Vector3(projectileSpeed * vec.x, projectileSpeed * vec.y, 0);
            ammunition--;
        }
    }
}
