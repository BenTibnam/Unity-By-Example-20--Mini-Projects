using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private Transform camTransform;
    [SerializeField] private float shakeTime;
    [SerializeField] private float shakeRange;

    private Vector3 originalPosition;

    IEnumerator ShakeCamera()
    {
        float elapsedTime = 0;
        while(elapsedTime < shakeTime)
        {
            Vector3 pos = originalPosition + Random.insideUnitSphere * shakeRange;
            pos.z = originalPosition.z;
            camTransform.position = pos;
            elapsedTime += Time.deltaTime;

            yield return null; // holds until the frame is finished
        }

        camTransform.position = originalPosition;
    }

    // Start is called before the first frame update
    void Start()
    {
        camTransform = this.transform;
        originalPosition = camTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine("ShakeCamera");
        }
    }
}
