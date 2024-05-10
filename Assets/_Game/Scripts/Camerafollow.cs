using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float smoothTime;
    public Vector3 _offset;
    private Vector3 _currentVelocity = Vector3.zero;
    private void Awake()
    {
        //_offset = transform.position - target.position;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        Vector3 targetPosition = target.position + _offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _currentVelocity, smoothTime);
        //Debug.Log(transform.position);
        
    }
}
