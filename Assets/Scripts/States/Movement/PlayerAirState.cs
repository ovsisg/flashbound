using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirState : EntityState
{
    public PlayerAirState(Player player, StateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        player.ResetCoyoteTime();
    }

    public override void Update()
    {
        base.Update();

        if (player.hasGameStarted)
            player.SetVelocity(player.moveSpeed, rb.velocity.y);
        else
            return;

        if (player.jumpBuffered && player.coyoteTime > 0 && !player.hasJumped)
        {
            player.ClearJumpBuffer();
            stateMachine.ChangeState(player.jumpState);
        }

        if (player.playerControls.Player.Jump.WasPressedThisFrame())
        {
            if (player.coyoteTime > 0 && !player.hasJumped)
                stateMachine.ChangeState(player.jumpState);

            if (!player.isGroundDetected)
                player.StartJumpBuffer();
        }
    }
}
