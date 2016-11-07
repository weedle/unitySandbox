using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {
    protected bool paused;
    protected bool pausedOnce;
	// Use this for initialization
	void Start () {
        paused = false;
        pausedOnce = false;
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            if (pausedOnce) return;
            pausedOnce = true;
            if (!paused)
            {
                GameObject[] objects = UnityEngine.Object.FindObjectsOfType<GameObject>();

                foreach (GameObject obj in objects)
                {
                    if (obj.GetComponent<ParticleAbstract>() != null)
                    {
                        ParticleAbstract particle = obj.GetComponent<ParticleAbstract>();
                        particle.pause();
                    }

                    if (obj.GetComponent<IntfShipController>() != null)
                    {
                        IntfShipController particle = obj.GetComponent<IntfShipController>();
                        particle.pause();
                    }
                }
            }
            else
            {
                GameObject[] objects = UnityEngine.Object.FindObjectsOfType<GameObject>();

                foreach (GameObject obj in objects)
                {
                    if (obj.GetComponent<ParticleAbstract>() != null)
                    {
                        ParticleAbstract particle = obj.GetComponent<ParticleAbstract>();
                        particle.unpause();
                    }

                    if (obj.GetComponent<IntfShipController>() != null)
                    {
                        IntfShipController particle = obj.GetComponent<IntfShipController>();
                        particle.unpause();
                    }
                }
            }
            paused = !paused;
        }
        if (Input.GetButtonUp("Pause"))
        {
            pausedOnce = false;
        }
    }
}
