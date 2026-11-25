using System;
using UnityEngine;

public class WalkState : PlayerState
{
    public WalkState (Player player) : base(player) { }

    public override void Enter () => player.playerAnimator.SetBool("IsRun", true);
    //Play("King Run");
    public override void Exit () => player.playerAnimator.SetBool("IsRun", false);
    public override void Tick ()
    {
        if(player.playerInput.Horizontal == 0f && player.onGround)
        {
            player.ChangeState(player.playerStates["King Idle"]);
        }
        if(player.playerInput.JumpPass && player.onGround)
        {
            if(Math.Abs(player.playerInput.Horizontal) > 0.01f)
            {
                player.ChangeState(player.playerStates["King Run"]);
            }
            if(player.playerInput.JumpPass)
            {
                player.ChangeState(player.playerStates["King Jump"]);
            }
        }
    }

    public override void FixedTick ()
    {
        Move(player.playerInput.Horizontal);
    }

    public void Move (float direction)
    {
        player.rigidbody.linearVelocity = new Vector2(
            direction * player.speed, player.rigidbody.linearVelocity.y
            );

        // Поворот спрайта в сторону движения
        if(direction != 0)
            player.rigidbody.transform.localScale = new Vector3(Mathf.Sign(direction), 1, 1);
    }
}
