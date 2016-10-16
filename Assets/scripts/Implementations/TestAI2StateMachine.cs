using UnityEngine;
using System;

public class TestAI2TStateMachine : MonoBehaviour, IntfTStateMachine
{
    private IntfTActionMachine turret;
    public String turretName;
    private bool active;
    private double currAngle;
    private MachineDefinitions.TState prevState;
    private MachineDefinitions.TState state;

    public double getDirection()
    {
        return currAngle;
    }

    public MachineDefinitions.TState getPrevState()
    {
        return prevState;
    }

    public MachineDefinitions.TState getState()
    {
        return state;
    }

    // Use this for initialization
    void Start()
    {
        currAngle = 0;
        prevState = MachineDefinitions.TState.Cooling;
        state = MachineDefinitions.TState.Inactive;
        setTurret(turretName);

        TestTActionMachine turretBadHack = null;
        turretBadHack = (TestTActionMachine)turret;
        turretBadHack.setRotationAmount(2);
    }


    public void setTurret(String turretName)
    {
        turret = gameObject.GetComponent<TestTActionMachine>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        determineState();
    }

    private void determineState()
    {
        if ((Input.GetAxis("Mouse X") == 0) &&
            (Input.GetAxis("Mouse Y") == 0))
        {
            Vector3 v3 = MachineDefinitions.getCursor();
            v3.x -= transform.position.x;
            v3.y -= transform.position.y;
            float mouseAngle = (float)Math.Atan2(v3.y, v3.x);
            mouseAngle += (float)Math.PI;
            //if (angle > Math.PI) angle = 2*(float)Math.PI - angle;
            //print("Angle: " + angle);

            Vector3 vec;
            vec = transform.rotation.eulerAngles;
            float turretAngle = vec.z;
            turretAngle = turretAngle * (float)Math.PI / 180;
            //if (angle2 > Math.PI) angle2 = 2 * (float)Math.PI - angle2;
            //print("Angle: " + angle2);
            float angleDiff = mouseAngle - turretAngle;
            //print("a1: " + mouseAngle + " a2: " + turretAngle + " ad: " + angleDiff);
            //print(angleDiff);
            if (Math.Abs(angleDiff) > 0.1)
            {
                turret.rotateClockwise();
            }
            else
            {
                turret.fireTurret();
            }
            /*
            turret in top (2pi to pi)
            left: 
            */
        }
        if (Input.GetButton("Fire1"))
        {
            if (turret.getActive() == false)
            {
                turret.goActive();
            }
            else
            {
                turret.goInactive();
            }
        }
    }
}
