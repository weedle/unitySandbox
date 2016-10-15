using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    private Animator anim;
    private Rigidbody2D rb2d;

    public float playerX;
    public float playerY;

    public Transform groundCheck;

    [HideInInspector]
    public bool facingRight = true;
    [HideInInspector]
    public bool jump = false;
    public bool grounded = true;
    public bool dash = true;

    public float maxHorzSpeed = 3;
    public float maxVertSpeed = 3;

    public enum MovementType
    {
        Standing, Walking, Running, Jumping,
        Midair, Dashing, Sneaking, Firing
    };

    public enum Direction
    {
        Left, Right
    };

    public struct State
    {
        public MovementType type;
        public Direction facing;
    };


    // state is the current player state
    // prevState is the last state we were in before
    //    we reached the current state
    // tempState is the state we were in last frame

    private State state;
    private State prevState;
    private State tempState;

    // Use this for initialization
    void Start() {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();

        state.type = MovementType.Standing;
        state.facing = Direction.Right;
    }

    // Update is called once per frame
    void Update() {

        playerX = transform.position.x;
        playerY = transform.position.y;

        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
    }

    void FixedUpdate()
    {
        // Here we figure out what's going on
        //    set 'state' variable to proper state
        determineState();

        // Use calculated state data to modify movement
        setMovement();

        // Here we use our knowledge of the current state and the history to display the right animations
        switch(state.type) {
            case MovementType.Running:
                if (state.facing == Direction.Left)
                    anim.Play("RunLeft");
                else if (state.facing == Direction.Right)
                    anim.Play("RunRight");
                break;
            case MovementType.Jumping:
                print(rb2d.velocity.y);
                if (state.facing == Direction.Left)
                    anim.Play("JumpLeft");
                else if (state.facing == Direction.Right)
                    anim.Play("JumpRight");
                break;
            case MovementType.Midair:
                print(rb2d.velocity.y);
                if (rb2d.velocity.y > 0)
                {
                    if (state.facing == Direction.Left)
                        anim.Play("MidairLeftUp");
                    else if (state.facing == Direction.Right)
                        anim.Play("MidairRightUp");
                }
                else
                {
                    if (state.facing == Direction.Left)
                        anim.Play("MidairLeftDown");
                    else if (state.facing == Direction.Right)
                        anim.Play("MidairRightDown");
                }
                break;
            case MovementType.Standing:
                if (state.facing == Direction.Left)
                    anim.Play("StandLeft");
                else if (state.facing == Direction.Right)
                    anim.Play("StandRight");
                break;
            case MovementType.Firing:
                if (state.facing == Direction.Left)
                    anim.Play("FireLeft");
                else if (state.facing == Direction.Right)
                    anim.Play("FireRight");
                break;
            default:
                break;
        }

        // Here we handle our stateH history, so we know what was going on
        if( !state.Equals(tempState) )
        {
            prevState = tempState;
        }

        tempState = state;
    }

    State determineState()
    {
        float h = Input.GetAxis("Horizontal");
        //float v = Input.GetAxis("Vertical");

        // Movement mechanics
        if (grounded)
        {
            // Holding Right
            if (Input.GetButton("Horizontal"))
            {
                state.type = MovementType.Running;
                if (h > 0)
                {
                    state.facing = Direction.Right;
                }
                // Holding Left
                else if (h < 0)
                {
                    state.facing = Direction.Left;
                }
                else
                {
                    state.type = MovementType.Standing;
                    state.facing = tempState.facing;
                }
            }
            else
            {
                state.type = MovementType.Standing;
                state.facing = tempState.facing;
            }
            if (Input.GetButton("Jump"))
            {
                state.type = MovementType.Jumping;
            }
            if (Input.GetButton("Fire1"))
            {
                state.type = MovementType.Firing;
            }
        }
        else if (!grounded)
        {
            state.type = MovementType.Midair;
            //if (rb2d.velocity.x > 0)
            //    state.facing = Direction.Right;
            //else if (rb2d.velocity.x < 0)
            //    state.facing = Direction.Left;
        }

        //print(state.type);
        return state;
    }

    void setMovement()
    {
        float h = Input.GetAxis("Horizontal");
        float horzSpeed = 0;
        float vertSpeed = 0;
        if ((state.type == MovementType.Jumping) &&
            (tempState.type != MovementType.Jumping))
        {
           vertSpeed = 1;
        }

        if (state.type == MovementType.Midair)
            horzSpeed = rb2d.velocity.x / maxHorzSpeed;

        if ((state.type == MovementType.Running) ||
             (state.type == MovementType.Jumping))
        {
            if (Input.GetButton("Horizontal"))
            {
                if (h > 0)
                    horzSpeed = 1;
                else if (h < 0)
                    horzSpeed = -1;
            }
            else
                horzSpeed = 0;
        }
        rb2d.velocity = new Vector2(horzSpeed * maxHorzSpeed, rb2d.velocity.y + vertSpeed * maxVertSpeed);

    }
}