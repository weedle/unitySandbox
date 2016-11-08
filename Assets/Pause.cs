using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {
    protected bool paused;
    protected bool pausedOnce;
    protected GameObject manualShip;
	// Use this for initialization
	void Start () {
        paused = false;
        pausedOnce = false;
        manualShip = null;
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
                        IntfShipController ctrl = obj.GetComponent<IntfShipController>();
                        ctrl.unpause();
                    }
                }
            }
            paused = !paused;
        }
        if (Input.GetButtonUp("Pause"))
        {
            pausedOnce = false;
        }

        if(paused)
        {
            Color targetLinePlayer = Color.green;
            Color targetLineEnemy = Color.red;
            targetLinePlayer.a = 30;

            GameObject[] objects = UnityEngine.Object.FindObjectsOfType<GameObject>();
            foreach (GameObject obj in objects)
            {
                if (obj.GetComponent<IntfShipController>() != null)
                {
                    IntfShipController ctrl = obj.GetComponent<IntfShipController>();
                    if(ctrl.GetType().Equals(typeof(ImplMainShipController)))
                    {
                        Vector3 bottomLeft = obj.transform.position - new Vector3(0.01f, 0.01f);
                        Vector3 topRght = obj.transform.position + new Vector3(0.01f, 0.01f);
                        ShipDefinitions.DrawSquare(bottomLeft, topRght, Color.yellow, 2*Time.deltaTime);
                    }
                }
            }
        }
    }

    public void requestManualControl(GameObject ship)
    {
        if(ship.Equals(manualShip))
        {
            return;
        }

        Destroy((Object) ship.GetComponent<IntfShipController>());
        ship.AddComponent<ImplMainShipController>();

        if(manualShip)
        {
            Destroy((Object)manualShip.GetComponent<IntfShipController>());
            manualShip.AddComponent<ImplBasicAIShipController>();
        }
        manualShip = ship;
    }
}
