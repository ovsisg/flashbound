using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundState : EntityState
{
    public PlayerGroundState(Player player, StateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        player.ClearCoyoteTime();
        player.SetHasJumped(false);
    }

    public override void Update()
    {
        base.Update();

        if (!player.hasGameStarted || player.hasJustStartedGame)
            return;

        if (player.playerControls.Player.Jump.WasPerformedThisFrame())
        {
            stateMachine.ChangeState(player.jumpState);
        }
    }
}
