using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraManager : MonoBehaviour
{
    private CinemachineVirtualCamera _virtualCamera;
    
    public bool freeView = true;
    
    private Transform _selectedObjectTransform;
    private Transform _cameraSystemTransform;
    
    // Start is called before the first frame update
    void Start()
    {
        _virtualCamera = FindObjectOfType<CinemachineVirtualCamera>();    
        _cameraSystemTransform = FindObjectOfType<CameraSystem>().transform;
        _selectedObjectTransform = _cameraSystemTransform;
        UpdateView();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Y)) return;
        UpdateView();
    }

    void UpdateView()
    {
        if (freeView)
        {
            _cameraSystemTransform.position = _selectedObjectTransform.position; // Camera reposition to last selected Object
            _virtualCamera.LookAt = _cameraSystemTransform;
            _virtualCamera.Follow = _cameraSystemTransform;
        }
        else
        {
            _virtualCamera.LookAt = _selectedObjectTransform;
            _virtualCamera.Follow = _selectedObjectTransform;        
        }
        freeView = !freeView;
    }

    public void UpdateLastSelectedObject(Transform selectedObject)
    {
        _selectedObjectTransform = selectedObject;
        freeView = true;
    }
}
