using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Construction
{
    [System.Serializable]
    public class Building : MonoBehaviour
    {
        [SerializeField] private Material previewMaterial;
        [SerializeField] private MeshRenderer objectRenderer;
        
        public Vector2Int gridPosition { get; internal set; }
        public BuildingStates state { get; internal set; }

        public enum BuildingStates
        {
            Preview,
            Constructing,
            Constructed,
        }
        
        internal void StartPreview()
        {
            state = BuildingStates.Preview;
            objectRenderer.materials = new[] {previewMaterial};
            objectRenderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
            objectRenderer.receiveShadows = false;
        }
    }
}
