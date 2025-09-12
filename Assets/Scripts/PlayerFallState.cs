using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallState : EntityState
{
    public PlayerFallState(Player player, StateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Update()
    {
        base.Update();

        if (player.isGroundDetected)
        {
            if (player.hasGameStarted)
                stateMachine.ChangeState(player.moveState);
            else    
                stateMachine.ChangeState(player.idleState);
        }
    }
}
