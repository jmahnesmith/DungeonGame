using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class Chase : State
{
    public Chase(AIPath aiPath, StateMachine stateMachine, EnemyMovement enemyMovement) : base(aiPath, stateMachine, enemyMovement)
    {
        
    }

    public override void Enter()
    {
        base.Enter();
        
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void HandleInput()
    {
        base.HandleInput();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
