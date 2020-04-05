using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region SINGLETON PATTERN
    public static Player _instance;
    public static Player Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<Player>();

                if (_instance == null)
                {
                    GameObject container = new GameObject("Bicycle");
                    _instance = container.AddComponent<Player>();
                }
            }

            return _instance;
        }
    }
    #endregion
    public static Transform PlayerLocation { get; private set; }
    void Update()
    {
        PlayerLocation = transform;
    }
}
