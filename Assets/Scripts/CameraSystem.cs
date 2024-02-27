using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour
{

    [SerializeField] private bool useEdgeScrolling = true;
    
    [SerializeField] private float cameraMoveSpeed = 50f;

    [SerializeField] private float cameraRotateDir = 0f;
    [SerializeField] private float cameraRotateSpeed = 100f;

    [SerializeField] private int edgeScrollSize = 30;
    
    private Transform _cachedTransform;

    private void Start()
    {
        // Cache the transform at the start
        _cachedTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        //Edges movements mechanisms
        if (useEdgeScrolling)
        {
            HandleEdgesMovement();
        }
        //Rotation mechanisms
        HandleRotation();
    }

    private void HandleEdgesMovement()
    {
        //Movement variables
        var inputDir = new Vector3(0, 0, 0);
        
        if (Input.mousePosition.x < edgeScrollSize) inputDir.x = -1f;
        if (Input.mousePosition.y < edgeScrollSize) inputDir.z = -1f;
        if (Input.mousePosition.x > Screen.width - edgeScrollSize) inputDir.x = +1f;
        if (Input.mousePosition.y > Screen.height - edgeScrollSize) inputDir.z = +1f;
    
        //Movements mechanisms
        var cameraMoveDir = _cachedTransform.forward * inputDir.z + _cachedTransform.right * inputDir.x;
        _cachedTransform.position += cameraMoveDir * (cameraMoveSpeed * Time.deltaTime);
    }
    private void HandleRotation()
    {
      //Rotations mechanisms
        cameraRotateDir = 0f;
        if (Input.GetKey(KeyCode.A)) cameraRotateDir = +1f;
        if (Input.GetKey(KeyCode.E)) cameraRotateDir = -1f;
        
        transform.eulerAngles += new Vector3(0, cameraRotateDir * cameraRotateSpeed * Time.deltaTime, 0);
    }

}
