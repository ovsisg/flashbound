using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallState : PlayerAirState
{
    public PlayerFallState(Player player, StateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Update()
    {
        base.Update();

        if (player.isGroundDetected)
        {
            if (player.jumpBuffered)
            {
                player.ClearJumpBuffer();
                stateMachine.ChangeState(player.jumpState);
            }
            else if (player.hasGameStarted)
            {
                stateMachine.ChangeState(player.moveState);
            }
            else
            {
                stateMachine.ChangeState(player.idleState);
            }    
        }
    }
}
