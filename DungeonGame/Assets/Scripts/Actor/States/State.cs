using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    protected AIPath aiPath;
    protected EnemyMovement enemyMovement;
    protected StateMachine stateMachine;

    public State(AIPath aiPath, StateMachine stateMachine, EnemyMovement enemyMovement)
    {
        this.aiPath = aiPath;
        this.stateMachine = stateMachine;
        this.enemyMovement = enemyMovement;
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
