using UnityEngine;
using System.Collections;

// The Turret State Machine Interface helps us determine and compute the current state of the turret
// It does *not* actually implement the state, that is left to TActionMachine.
// The reason for this is that we can carry out the actions of the turret regardless of who's controlling it
// Turrets that are AI-controlled or player-controlled will be implemented the same way (on the action level), 
// and swapping control of a turret from the player to an AI or vice-versa should be as simple as assigning 
// a different StateMachine script to it
public interface IntfTStateMachine {
    // Return the current state of the turret
    MachineDefinitions.TState getState();

    // Return the previous state of the turret
    MachineDefinitions.TState getPrevState();

    // Return the current direction the turret is pointing in
    double getDirection();
}
