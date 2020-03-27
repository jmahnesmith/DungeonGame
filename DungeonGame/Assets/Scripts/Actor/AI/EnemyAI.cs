using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    StateMachine stateMachine;
    AIPath aiPath;
    EnemyMovement enemyMovement;
    Rigidbody2D playerPosition;
    Chase chase;

    private void Start()
    {
        stateMachine = new StateMachine();
        chase = new Chase(aiPath, stateMachine, enemyMovement);
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
