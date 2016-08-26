using UnityEngine;
using System.Collections;
using System;

public class TestTActionMachine : MonoBehaviour, IntfTActionMachine {
    int countDown = 0;
    string command = "";
    string nextCommand = "";

    public void findTarget()
    {
        throw new NotImplementedException();
    }

    public void fireTurret()
    {
        throw new NotImplementedException();
    }

    public void goActive()
    {
        throw new NotImplementedException();
    }

    public void goInactive()
    {
        throw new NotImplementedException();
    }

    private void rotate(int z)
    {
        if (countDown != 0)
        {
            transform.Rotate(new Vector3(0, 0, z));
            countDown--;
        } else
        {
            command = "";
        }
    }

    public void rotateCounterClockwise()
    {
        nextCommand = "rccw";
    }

    public void rotateClockwise()
    {
        nextCommand = "rcw";
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        print("Next command is: " + nextCommand + "\n");

        if ( command == "" )
        {
            command = nextCommand;
            nextCommand = "";
            countDown = 50;
        }
	    switch(command)
        {
            case "rcw":
                rotate(-1);
                break;
            case "rccw":
                rotate(1);
                break;
        }
	}
}
