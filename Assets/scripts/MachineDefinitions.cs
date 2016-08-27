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
    // Not all state types will be used for all turrets
    public enum TState
    {
        Inactive, Searching, Aiming, Firing, Cooling, Querying
    }

    // General rules for interactions between Factions
    // Player and PlayerAffil will target Enemy and Rogue
    // Enemy will target Player and PlayerAffil
    // Rogue will fire on all targets except possibly other Rogues
    // Indep will fire on no targets unless fired upon
    // Relationships are entity-dependent, and will be dynamically
    // assigned during gameplay
    public enum Faction
    {
        Player, PlayerAffil, Enemy, Rogue, Indep
    }
}
