using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public bool onGround = true;
    public Animator playerAnimator;
    public Rigidbody2D rigidbody;
    public PlayerInput playerInput;
    public Dictionary<string, PlayerState> playerStates = new();
    private PlayerState _currentState;


    void Start ()
    {
        StatesRegister();
    }

    void StatesRegister ()
    {
        playerStates.Add("King Idle", new IdleState(this));
        playerStates.Add("King Run", new WalkState(this));
        playerStates.Add("King Jump", new JumpState(this));
        //playerStates.Add("Idle", new IdleState(this));

        _currentState = playerStates["King Idle"];
    }

    public void ChangeState (PlayerState nextState)
    {
        _currentState.Exit();
        _currentState = nextState;
        _currentState.Enter();
    }

    private void Update ()
    {
        _currentState.Tick();
    }

    private void FixedUpdate ()
    {
        _currentState.FixedTick();
    }

}
