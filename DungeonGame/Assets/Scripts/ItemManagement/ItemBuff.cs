using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemBuff
{
    public ItemAttribute attribute;
    public int value;
    public int min;
    public int max;
    public ItemBuff(int _min, int _max)
    {
        min = _min;
        max = _max;
    }
    public void GenerateValue()
    {
        value = Random.Range(min, max);
    }
}
