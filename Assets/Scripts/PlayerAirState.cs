using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirState : EntityState
{
    public PlayerAirState(Player player, StateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Update()
    {
        base.Update();

        if (player.hasGameStarted)
            player.SetVelocity(player.moveSpeed, rb.velocity.y);

        if (player.playerControls.Player.Jump.WasPressedThisFrame())
        {
            if (!player.isGroundDetected)
                player.StartJumpBuffer();
        }
    }
}
