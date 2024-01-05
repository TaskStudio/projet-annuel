using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameInput
{
    public class MouseControl : MonoBehaviour
    {
        [SerializeField] private Camera mainCamera;
        [SerializeField] private LayerMask groundLayer;

        private Vector3 lastPosition;

        public Vector3 GetCursorMapPosition()
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = mainCamera.nearClipPlane;
            Ray ray = mainCamera.ScreenPointToRay(mousePos);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100f, groundLayer))
            {
                lastPosition = hit.point;
            }

            return lastPosition;
        }
    }
}
