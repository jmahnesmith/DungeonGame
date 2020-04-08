using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : State
{
    public Chase(AstarAI astarAI, Actor actor, Vision vision) : base(astarAI, actor, vision)
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
        Vector3 dir = (astarAI.path.vectorPath[astarAI.currentWaypoint] - astarAI.transform.position).normalized;

        if (vision.canSeePlayer())
        {
            actor.RotateOverTime(actor.rb.transform.position, Player.PlayerLocation.position, 0.2f);
        }
        else
            actor.RotateOverTime(actor.rb.transform.position, astarAI.path.vectorPath[astarAI.currentWaypoint + 1], 0.2f);

        // Multiply the direction by our desired speed to get a velocity
        Vector3 velocity = dir * actor.speed;
        // Note that SimpleMove takes a velocity in meters/second, so we should not multiply by Time.deltaTime
        actor.Move(velocity);

    }
}
