using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : EntityState
{
    public PlayerIdleState(Player player, StateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Update()
    {
        base.Update();

        if (player.hasGameStarted)
            stateMachine.ChangeState(player.moveState);
    }
}
