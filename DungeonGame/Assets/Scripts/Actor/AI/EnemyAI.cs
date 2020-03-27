using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    StateMachine stateMachine;
    Chase chase;

    private void Start()
    {
        stateMachine = new StateMachine();
        chase = new Chase(GetComponent<AIPath>(), stateMachine, GetComponent<EnemyMovement>());

        stateMachine.Initialize(chase);

    }
    private void Update()
    {
        stateMachine.CurrentState.HandleInput();
        stateMachine.CurrentState.LogicUpdate();
    }
    private void FixedUpdate()
    {
        stateMachine.CurrentState.PhysicsUpdate();
    }
}
