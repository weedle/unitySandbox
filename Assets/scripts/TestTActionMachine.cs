using UnityEngine;
using System.Collections;
using System;

public class TestTActionMachine : MonoBehaviour, IntfTActionMachine
{
    private Animator anim;
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

    private void goInactiveImpl()
    {
        if (countDown != 0)
        {
            anim.Play("Inactive");
            countDown--;
        }
        else
        {
            command = "";
        }
    }

    private void goActiveImpl()
    {
        if (countDown != 0)
        {
            anim.Play("Active");
            countDown--;
        }
        else
        {
            command = "";
        }
    }

    public void goActive()
    {
        nextCommand = "active";
    }

    public void goInactive()
    {
        nextCommand = "inactive";
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
    void Start ()
    {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if ( command == "" )
        {
            command = nextCommand;
            nextCommand = "";
            countDown = 20;
        }
	    switch(command)
        {
            case "rcw":
                rotate(-1);
                break;
            case "rccw":
                rotate(1);
                break;
            case "active":
                goActiveImpl();
                break;
            case "inactive":
                goInactiveImpl();
                break;
        }
	}
}
