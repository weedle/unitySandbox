using UnityEngine;
using System.Collections;


// IntfShip provides the interface for all ships
// Having both enemies and allies follow the same interface
// means we can easily have faction changing, switching from 
// manual to AI or vice versa, and other neat little things
// Note: This does not direct the ship, it simply determines how
// each action is implemented
public interface IntfShip {
    ShipDefinitions.SState getState();

    float getAngle();

    void brake();

    void start();

    void stop();

    void move(float vertical);

    void rotate(float horizontal);

    void fire();

    float getEffectiveDistance();

    float getEffectiveAngle();

    string getName();

}
