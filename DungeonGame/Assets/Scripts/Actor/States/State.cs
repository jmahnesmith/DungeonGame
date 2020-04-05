using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    private AstarAI path;
    public State(AstarAI path)
    {
        this.path = path;
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
