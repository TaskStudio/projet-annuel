using GameInput;
using UnityEngine;

namespace Construction
{
    public class PlacementSystem : MonoBehaviour
    {
        [SerializeField] private Grid grid;
        [SerializeField] private MouseControl mouseControl;
        [SerializeField] private BuildingDatabaseSO buildingDatabase;

        private GridData buildingData;
        private bool isBuildingSelected;
        private Building selectedBuilding;
        private int selectedBuildingID;

        private void Start()
        {
            isBuildingSelected = false;
            buildingData = new GridData();
        }

        private void Update()
        {
            if (isBuildingSelected && selectedBuilding.state == Building.BuildingStates.Preview)
            {
                Vector3 worldMousePos = mouseControl.GetCursorMapPosition();
                Vector3Int gridMousePos = grid.WorldToCell(worldMousePos);
                Vector3 gridWorldPos = grid.CellToWorld(gridMousePos);
                selectedBuilding.transform.position = gridWorldPos;

                Vector2Int buildingSize = buildingDatabase.buildingsData.Find(x => x.ID == selectedBuildingID).Size;

                bool canPlace = buildingData.CanPlaceObjectAt(gridMousePos, buildingSize);
                if (!canPlace)
                    selectedBuilding.PreviewInvalid();
                else
                    selectedBuilding.PreviewValid();
            }
        }

        public void StartPlacement(int ID)
        {
            CancelPlacement();
            selectedBuilding = Instantiate(buildingDatabase.buildingsData.Find(x => x.ID == ID).Prefab);
            selectedBuilding.PreviewValid();
            selectedBuildingID = ID;

            isBuildingSelected = selectedBuilding != null;
            mouseControl.OnClicked += PlaceBuilding;
            mouseControl.OnExit += CancelPlacement;
        }

        private void PlaceBuilding()
        {
            if (mouseControl.IsPointerOverUI())
                return;

            Vector3 worldMousePos = mouseControl.GetCursorMapPosition();
            Vector3Int gridMousePos = grid.WorldToCell(worldMousePos);

            Vector2Int buildingSize = buildingDatabase.buildingsData.Find(x => x.ID == selectedBuildingID).Size;

            bool canPlace = buildingData.CanPlaceObjectAt(gridMousePos, buildingSize);
            if (!canPlace)
                return;

            buildingData.AddObjectAt(gridMousePos, buildingSize, selectedBuildingID, 0);
            selectedBuilding.Construct();
            selectedBuilding = null;
            isBuildingSelected = false;

            mouseControl.OnClicked -= PlaceBuilding;
            mouseControl.OnExit -= CancelPlacement;
        }


        public void CancelPlacement()
        {
            if (isBuildingSelected)
            {
                Destroy(selectedBuilding.gameObject);
                selectedBuilding = null;
                isBuildingSelected = false;
            }
        }
    }
}