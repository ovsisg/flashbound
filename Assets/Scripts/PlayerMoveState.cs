using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : EntityState
{
    public PlayerMoveState(Player player, StateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Update()
    {
        base.Update();
        
        if (player.playerControls.Player.Jump.WasPerformedThisFrame())
            stateMachine.ChangeState(player.jumpState);   

        player.SetVelocity(player.moveSpeed, rb.velocity.y);
    }
}
