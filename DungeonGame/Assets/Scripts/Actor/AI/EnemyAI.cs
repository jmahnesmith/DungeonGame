using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    public StateMachine stateMachine { get; private set; }
    public AIPath aiPath { get; private set; }
    public EnemyMovement enemyMovement { get; private set; }
    public Vector3 playerPosition { get; private set; }

    private Chase chase;

    private void Awake()
    {
        aiPath = GetComponent<AIPath>();
        enemyMovement = GetComponent<EnemyMovement>();
        playerPosition = aiPath.destination;
    }

    private void Start()
    {
        stateMachine = new StateMachine();
        chase = new Chase(this);
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
