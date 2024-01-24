using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using GameInput;
using UnityEngine.Serialization;


namespace Construction
{
    public class PlacementSystem : MonoBehaviour
    {
        [SerializeField] private Grid grid;
        [SerializeField] private MouseControl mouseControl;
        [SerializeField] private BuildingDatabaseSO buildingDatabase;
        
        private Building selectedBuilding;
        private bool _isBuildingSelected;

        private void Start()
        {
            _isBuildingSelected = false;
        }

        public void StartPlacement(int ID)
        {
            StopPlacement();
            selectedBuilding = Instantiate(buildingDatabase.buildingsData.Find(x => x.ID == ID).Prefab);
            selectedBuilding.StartPreview();
            
            _isBuildingSelected = selectedBuilding != null;
        }

        public void StopPlacement()
        {
            if (_isBuildingSelected)
            {
                Destroy(selectedBuilding.gameObject);
                selectedBuilding = null;
                _isBuildingSelected = false;
            }
        }

        private void Update()
        {
            if (_isBuildingSelected && selectedBuilding.state == Building.BuildingStates.Preview)
            {
                Vector3 worldMousePos = mouseControl.GetCursorMapPosition();
                Vector3Int gridMousePos = grid.WorldToCell(worldMousePos);
                Vector3 gridWorldPos = grid.CellToWorld(gridMousePos);
                selectedBuilding.gridPosition = new Vector2Int(gridMousePos.x, gridMousePos.y);
                selectedBuilding.transform.position = gridWorldPos;
            }
        }
    }
}
