using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    public StateMachine stateMachine { get; private set; }

    private AstarAI astarAI;

    private Actor actor;

    public Vision vision;

    private void Awake()
    {
        astarAI = GetComponent<AstarAI>();
        actor = GetComponent<Actor>();
    }

    Chase chase;
    private void Start()
    {
        astarAI = GetComponent<AstarAI>();
        stateMachine = new StateMachine();
        chase = new Chase(astarAI, actor, vision);
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
