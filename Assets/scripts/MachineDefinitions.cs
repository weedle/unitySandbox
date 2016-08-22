using UnityEngine;
using System.Collections;

// Contains various definitions that will be useful for other scripts
public class MachineDefinitions {

    // HUMANOID DEFINITIONS

    // Not all States are compatible with all Directions
    // Eg, while Standing is a state that can be association with any Direction,
    // Running has to be either Left or Right
    public enum HState
    {
        Standing, Walking, Running, Jumping,
        Midair, Dashing, Sneaking, Firing
    };

    public enum HDirection
    {
        Left, Right, Forward, Backward
    };

    // TURRET DEFINITIONS

    // Turrets are limited in their state types, but can point in any direction
    // I'm thinking one possible behaviour for turrets should be to shoot periodically
    // at enemies in range, but increase firing priority if an enemy enters close range
    // Perhaps firing rate could increase heat, so a turret could potentially get overwhelmed
    public enum TState
    {
        Inactive, Aiming, Firing, Cooling
    }
}
