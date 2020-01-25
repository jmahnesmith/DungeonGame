using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PossibleRoom : MonoBehaviour
{
    public string sceneName;
    public int maxSpawns;
    public int counter = 0;
    private void Start()
    {
        counter = 0;
    }
}
