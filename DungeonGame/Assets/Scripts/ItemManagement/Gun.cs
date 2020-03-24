using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : ScriptableObject
{
    public int itemID;
    public string gunName;
    public string gunDesc;
    public Sprite gunSprite;
    public AudioClip gunSound;
    public float gunBaseCoolDown = 1f;

    public abstract void Initialize(GameObject gameObject);
    public abstract void TriggerItem();
}
