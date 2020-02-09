using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject[] itemPrefabs;
    void Start()
    {
        int randomNumber = Random.Range(0, itemPrefabs.Length);
        Instantiate(itemPrefabs[randomNumber]);
    }
}
