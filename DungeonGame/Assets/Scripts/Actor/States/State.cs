using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    public AstarAI astarAI;
    public Actor actor;
    public Vision vision;
    public State(AstarAI astarAI, Actor actor, Vision vision)
    {
        this.astarAI = astarAI;
        this.actor = actor;
        this.vision = vision;
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
