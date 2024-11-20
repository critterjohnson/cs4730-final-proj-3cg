using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 offset;
    private Vector3 velocity;
    public float smoothTime;
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(0, 0, -10f);
        velocity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
