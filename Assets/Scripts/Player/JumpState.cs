using UnityEngine;

public class JumpState : PlayerState
{
    public JumpState (Player player) : base(player) { }
    public override void Enter ()
    {
        player.onGround = false;
        player.playerAnimator.SetBool("IsJump", true);
        player.rigidbody.linearVelocity = new Vector2 (
            player.rigidbody.linearVelocity.x, 
            player.jumpForce);
    }
    public override void Exit () 
    {
        player.playerInput.JumpPass = false;
        player.playerAnimator.SetBool("IsJump", false);
    } 

    public override void FixedTick ()
    {
        Move(player.playerInput.Horizontal * 0.7f);
        if(player.onGround)
        {
            player.ChangeState(player.playerStates["King Idle"]);
        };
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
