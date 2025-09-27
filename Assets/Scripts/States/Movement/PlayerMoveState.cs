using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerGroundState
{
    public PlayerMoveState(Player player, StateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Update()
    {
        base.Update();
        
        if (!player.isGroundDetected)
            stateMachine.ChangeState(player.fallState);

        if (player.isWallDetected)
        {
            player.ResetSpeed();
            player.SetVelocity(0, rb.velocity.y);

            if (!player.isGroundDetected)
                stateMachine.ChangeState(player.fallState);
            else
                stateMachine.ChangeState(player.idleState);
        }

        player.SetVelocity(player.moveSpeed, rb.velocity.y);
    }
}
