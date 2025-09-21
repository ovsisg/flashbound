using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadGroundState : PlayerDeadState
{
    public PlayerDeadGroundState(Player player, StateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }
}
