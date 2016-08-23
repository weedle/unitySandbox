using UnityEngine;
using System.Collections;
using System;

public class TestTStateMachine : MonoBehaviour, IntfTStateMachine
{
    private double currAngle;
    private MachineDefinitions.TState prevState;
    private MachineDefinitions.TState state;
    bool active;

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
        active = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        determineState();

        print("State of turret is:" + state.ToString() + "\n");
    }

    private void determineState()
    {
        float h = Input.GetAxis("Horizontal");
        if (Input.GetButton("Horizontal"))
        {
            if (h > 0)
            {
            }
            // Holding Left
            else if (h < 0)
            {
            }
        }
        if (Input.GetButton("Fire1"))
        {
            if( active == false )
            {
                active = true;
            }
        }
    }