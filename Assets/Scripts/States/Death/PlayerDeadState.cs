using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadState : EntityState
{
    public PlayerDeadState(Player player, StateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        player.SetVelocity(0, 0);
        player.rb.bodyType = RigidbodyType2D.Static;
    }
}
