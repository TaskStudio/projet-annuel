using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour
{

    public float cameraMoveSpeed = 50f;

    public float cameraRotateDir = 0f;
    public float cameraRotateSpeed = 100f;

    public int edgeScrollSize = 30;
    
    private Transform cachedTransform;

    private void Start()
    {
        // Cache the transform at the start
        cachedTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        //Movement variables
        Vector3 inputDir = new Vector3(0, 0, 0);
        
        //Edges mechanisms
        if (Input.mousePosition.x < edgeScrollSize) inputDir.x = -1f;
        if (Input.mousePosition.y < edgeScrollSize) inputDir.z = -1f;
        if (Input.mousePosition.x > Screen.width - edgeScrollSize) inputDir.x = +1f;
        if (Input.mousePosition.y > Screen.height - edgeScrollSize) inputDir.z = +1f;
        
        Vector3 cameraMoveDir = cachedTransform.forward * inputDir.z + cachedTransform.right * inputDir.x;
        cachedTransform.position += cameraMoveDir * (cameraMoveSpeed * Time.deltaTime);
        
        //Rotations mechanisms
        cameraRotateDir = 0f;
        if (Input.GetKey(KeyCode.A)) cameraRotateDir = +1f;
        if (Input.GetKey(KeyCode.E)) cameraRotateDir = -1f;
        
        transform.eulerAngles += new Vector3(0, cameraRotateDir * cameraRotateSpeed * Time.deltaTime, 0);
    }
}
