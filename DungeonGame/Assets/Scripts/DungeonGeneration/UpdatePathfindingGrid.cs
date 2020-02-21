using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatePathfindingGrid : MonoBehaviour
{
    private void Start()
    {
        FindObjectOfType<DungeonGenerator>().GenerationCompleteEvent += UpdatePathfindingGrid_GenerationCompleteEvent;
    }
    private void UpdatePathfindingGrid_GenerationCompleteEvent()
    {
        FindObjectOfType<DungeonGenerator>().GenerationCompleteEvent -= UpdatePathfindingGrid_GenerationCompleteEvent;
        StartCoroutine(UpdateGrid());

    }

    IEnumerator UpdateGrid()
    {
        foreach (Progress progress in AstarPath.active.ScanAsync())
        {

            //Debug.Log("Scanning... " + progress.description + " - " + (progress.progress * 100).ToString("0") + "%");
            yield return null;
        }
    }
}
