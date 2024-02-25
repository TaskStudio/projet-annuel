using System;
using UnityEngine;
using UnityEngine.Rendering;

namespace Construction
{
    [Serializable]
    public class Building : MonoBehaviour
    {
        public enum BuildingStates
        {
            Preview,
            Constructing,
            Constructed
        }

        [SerializeField] private Material previewMaterial;
        [SerializeField] private MeshRenderer objectRenderer;

        // public Vector2Int gridPosition { get; internal set; }
        public BuildingStates state { get; internal set; }

        internal void StartPreview()
        {
            state = BuildingStates.Preview;
            objectRenderer.materials = new[] { previewMaterial };
            objectRenderer.shadowCastingMode = ShadowCastingMode.Off;
            objectRenderer.receiveShadows = false;
        }

        internal void Construct()
        {
            state = BuildingStates.Constructing;
        }
    }
}