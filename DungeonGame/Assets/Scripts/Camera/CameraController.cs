using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;
    private Room _currRoom;
    public Room currRoom

    {
        get { return _currRoom; }
        set
        {
            if(_currRoom != value)
            {
                if (nextRoomDelegate != null)
                {
                    nextRoomDelegate();
                    Debug.Log("OnNextRoom Triggered");
                }
                Debug.Log("New Room " + value.name);
                _currRoom = value;
                
            }
        }
    }

    public float moveSpeedWhenRoomChanged;

    public float xOffset;

    public float yOffset;

    public delegate void OnNextRoom();
    public event OnNextRoom nextRoomDelegate;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePosition();
        
    }

    private void UpdatePosition()
    {
        if(currRoom == null)
        {
            return;
        }

        Vector3 targetPos = GetCameraTargetPosition();

        transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * moveSpeedWhenRoomChanged);
    }

    private Vector3 GetCameraTargetPosition()
    {
        if (currRoom == null)
        {
            return Vector3.zero;
        }

        Vector3 targetPos = currRoom.GetRoomCenter() + new Vector3(xOffset, yOffset, 0);
        targetPos.z = transform.position.z;

        return targetPos;
    }

    public bool IsSwitchingScene()
    {
        return transform.position.Equals(GetCameraTargetPosition()) == false;
    }
}
