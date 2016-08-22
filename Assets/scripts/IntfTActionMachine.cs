using UnityEngine;
using System.Collections;

// The Turret Action Machine Interface uses the State Machine available to this turret to, well, 
// make it do stuff. All the logic is relegated to the State Machine, the Action Machine simply 
// implements a given state (eg, Firing, Cooling).
public interface IntfTActionMachine {

    // Rotate the turret some degree clockwise
    // Exactly how much it rotates should depend on the turret
    // Eg, maybe a small turret can rotate in tiny increments, and 
    // a larger variant can only turn a tiny fraction of a radian at a time
    void rotateClockwise();

    // Rotate the turret some degree counterclockwise
    void rotateCounterClockwise();

    void fireTurret();

    void goInactive();

    void goActive();

    void findTarget();
}
