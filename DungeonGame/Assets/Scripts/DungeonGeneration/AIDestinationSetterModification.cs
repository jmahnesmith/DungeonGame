using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AIDestinationSetterModification : MonoBehaviour
{
    AIDestinationSetter aiDestinationSetter;
    // Start is called before the first frame update
    void Awake()
    {
        aiDestinationSetter = GetComponent<AIDestinationSetter>();
        aiDestinationSetter.target = FindObjectOfType<Player>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
