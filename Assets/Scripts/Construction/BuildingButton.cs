using UnityEngine;

namespace Construction
{
    public class BuildingButton : MonoBehaviour
    {
        // [SerializeField] private TextMeshPro buttonText;
        public PlacementSystem placementSystem { get; internal set; }
        public int buildingID { get; internal set; }
        public string buildingName { get; internal set; }


        public void Initialize(int buildingID, string buildingName, PlacementSystem placementSystem)
        {
            this.buildingID = buildingID;
            this.buildingName = buildingName;
            this.placementSystem = placementSystem;
            // buttonText.text = buildingName;
        }

        public void ClickHandler()
        {
            placementSystem.StartPlacement(buildingID);
        }
    }
}