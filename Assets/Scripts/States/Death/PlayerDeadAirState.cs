using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadAirState : PlayerDeadState
{
    public PlayerDeadAirState(Player player, StateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }
}
