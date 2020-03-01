using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    CameraController cameraController;
    Vector3 originalPos;

    private void Start()
    {
        cameraController = GetComponent<CameraController>();
    }
    public IEnumerator Shake (float duration, float magnitude)
    {
        

        originalPos = transform.localPosition;

        //Debug.Log(originalPos);

        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x, y, originalPos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPos;
    }

    private void Update()
    {
        
    }
}
