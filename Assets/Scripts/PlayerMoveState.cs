using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : EntityState
{
    private float idleDelay = 0.1f;
    private float idleTimer = 0; 

    public PlayerMoveState(Player player, StateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Update()
    {
        base.Update();

        // Check if the horizontal input is near zero
        if (Mathf.Abs(player.moveInput.x) < 0.1f)
        {
            player.SetVelocity(0, rb.velocity.y); // Stop the horizontal movement to prevent the player from sliding

            idleTimer += Time.deltaTime; // Accumulate how much time has passed in total while the player is idle

            // If the player has been idle for longer than the delay
            if (idleTimer >= idleDelay) 
                stateMachine.ChangeState(player.idleState);
        }
        else
        {
            idleTimer = 0;
            player.SetVelocity(player.moveInput.x * player.moveSpeed, rb.velocity.y); 
        }
    }
}
