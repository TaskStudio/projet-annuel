using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameInput;


namespace Construction
{
    public class PlacementSystem : MonoBehaviour
    {
        [SerializeField] private Grid grid;
        [SerializeField] private MouseControl mouseControl;
        [SerializeField] private GameObject building;

        private void Update()
        {
            Vector3 worldMousePos = mouseControl.GetCursorMapPosition();
            Vector3Int gridMousePos = grid.WorldToCell(worldMousePos);
            building.transform.position = grid.CellToWorld(gridMousePos);
        }
    }
}
