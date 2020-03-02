using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    private Transform objectThatWillRotate;
    public float strength = 0.5f;
    float rotationValue;
    // Start is called before the first frame update
    void Start()
    {
        objectThatWillRotate = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
        rotationValue += strength;
        Quaternion rotation = objectThatWillRotate.transform.localRotation;
        rotation.eulerAngles = new Vector3(0.0f, 0.0f, rotationValue);
        objectThatWillRotate.transform.localRotation = rotation;
    }
}
