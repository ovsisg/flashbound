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
        
        if (player.isWallDetected)
        {
            player.SpeedReset();
            player.SetVelocity(0, rb.velocity.y);
            stateMachine.ChangeState(player.idleState);
        }

        player.SetVelocity(player.moveSpeed, rb.velocity.y);
    }
}
