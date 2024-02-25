using Building;
using GameInput;
using UnityEngine;

namespace Construction
{
    public class PlacementSystem : MonoBehaviour
    {
        [SerializeField] private Grid grid;
        [SerializeField] private MouseControl mouseControl;
        [SerializeField] private BuildingDatabaseSO buildingDatabase;
        private bool _isBuildingSelected;

        private GridData gridData;
        private Building selectedBuilding;

        private void Start()
        {
            _isBuildingSelected = false;
            gridData = new GridData();
        }

        private void Update()
        {
            if (_isBuildingSelected && selectedBuilding.state == Building.BuildingStates.Preview)
            {
                var worldMousePos = mouseControl.GetCursorMapPosition();
                var gridMousePos = grid.WorldToCell(worldMousePos);
                var gridWorldPos = grid.CellToWorld(gridMousePos);
                // selectedBuilding.gridPosition = new Vector2Int(gridMousePos.x, gridMousePos.y);
                selectedBuilding.transform.position = gridWorldPos;
            }
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
    }
}