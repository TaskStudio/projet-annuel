using UnityEngine;

namespace GameEntities
{
    public abstract class Previewable : MonoBehaviour
    {
        [SerializeField] private Material previewMaterial;

        void StartPreview()
        {
            GetComponent<MeshRenderer>().materials = new[] {previewMaterial};
        }
    }
}
