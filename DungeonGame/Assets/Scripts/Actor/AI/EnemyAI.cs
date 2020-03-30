using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    public StateMachine stateMachine { get; private set; }

    public AIPath aiPath;

    //Chase chase;
    private void Start()
    {
        aiPath = GetComponent<AIPath>();
        stateMachine = new StateMachine();
        //chase = new Chase(this);
        //stateMachine.Initialize(chase);

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
