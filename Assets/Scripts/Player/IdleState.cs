using System;
using UnityEngine;

public class IdleState : PlayerState
{
    public IdleState (Player player) : base(player) { }
    public override void Enter () => player.playerAnimator.Play("King Idle");

    public override void Tick ()
    {
        if(Math.Abs(player.playerInput.Horizontal) > 0.01f)
        {
            player.ChangeState(player.playerStates["King Run"]);
        }
        if (player.playerInput.JumpPass)
        {
            player.ChangeState(player.playerStates["King Jump"]);
        }
    }
}
