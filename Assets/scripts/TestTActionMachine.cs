using UnityEngine;
using System.Collections;
using System;

public class TestTActionMachine : MonoBehaviour, IntfTActionMachine
{
    private Animator anim;
    int FRAMESKIPCONST = 30;
    int frameskip;
    // cooldown until action can be performed
    int cooldown = 0;
    string command = "inactive";
    string nextCommand = "";
    bool active = false;
    public Rigidbody projectile;

    public void findTarget()
    {
        throw new NotImplementedException();
    }

    public void fireTurret()
    {
        if (active)
        {
            Vector3 vec;
            Rigidbody proj;
            vec = new Vector3((float)-0.75, 0, 0);
            vec = transform.rotation * vec;
            proj = (Rigidbody)Instantiate(projectile, new Vector3(transform.position.x, transform.position.y) + vec, Quaternion.Euler(0, 0, 0));
            proj.velocity = new Vector3(4 * vec.x, 4 * vec.y, 0);
        }
    }

    private void goInactiveImpl()
    {
        anim.Play("Inactive");
        active = false;
        command = "";
    }

    private void goActiveImpl()
    {
        anim.Play("Active");
        active = true;
        command = "";
    }

    public void goActive()
    {
        if( !active && frameskip <= 0 )
            nextCommand = "active";
    }

    public void goInactive()
    {
        if ( active && frameskip <= 0 )
            nextCommand = "inactive";
    }

    public void toggleActive()
    {

    }

    private void rotate(int z)
    {
        transform.Rotate(new Vector3(0, 0, z));
        command = "";
    }

    public void rotateCounterClockwise()
    {
        if( active )
            nextCommand = "rccw";
    }

    public void rotateClockwise()
    {
        if ( active )
            nextCommand = "rcw";
    }

    public bool getActive()
    {
        return active;
    }

    // Use this for initialization
    void Start ()
    {
        anim = GetComponent<Animator>();
        frameskip = FRAMESKIPCONST;
    }

    // Update is called once per frame
    void Update()
    {
        //print(frameskip + " : " + active + " : " + frameskip + " : " + nextCommand);
        if( command == "" )
        {
            command = nextCommand;
            nextCommand = "";
        }
        switch (command)
        {
            case "rcw":
                rotate(-1);
                break;
            case "rccw":
                rotate(1);
                break;
            case "fire":
                fireTurret();
                break;
            case "active":
                goActiveImpl();
                frameskip = FRAMESKIPCONST;
                break;
            case "inactive":
                goInactiveImpl();
                frameskip = FRAMESKIPCONST;
                break;
            default:
                break;
        }
        if( frameskip >= 0 )
            frameskip--;
    }

    public void OnMouseDown()
    {
        IntfTStateMachine core = GameObject.
                    Find("GameCore").GetComponent<TestTStateMachine>();
        core.setTurret(this.name);

    }
}
