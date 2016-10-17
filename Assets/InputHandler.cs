using UnityEngine;
using System.Collections;

public class InputHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public bool getFire1()
    {
        return Input.GetButton("Fire1");
    }

    public bool getFire2()
    {
        return Input.GetButton("Fire2");
    }

    public bool getZ()
    {
        return Input.GetButton("z");
    }

    public bool getX()
    {
        return Input.GetButton("x");
    }

    public bool getC()
    {
        return Input.GetButton("c");
    }
}
