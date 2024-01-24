using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewSystem : MonoBehaviour
{
    [SerializeField] private GameObject previewObject;
    [SerializeField] private GameObject previewMaterialPrefab;
    [SerializeField] private GameObject previewMaterialInstance;

    void Start()
    {
        previewMaterialInstance = new Material(previewMaterialPrefab);
    }

    void Update()
    {
        
    }
}
