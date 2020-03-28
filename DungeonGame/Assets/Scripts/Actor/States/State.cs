using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    EnemyAI enemyAI;

    public State(EnemyAI enemyAI)
    {
        this.enemyAI = enemyAI;
        enemyAI.aiPath.canMove = true;
    }
    public virtual void Enter()
    {

    }
    public virtual void HandleInput()
    {

    }
    public virtual void LogicUpdate()
    {

    }
    public virtual void PhysicsUpdate()
    {

    }
    public virtual void Exit()
    {

    }
}
