using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Construction
{
    public class BuildingButton : Button 
    {
        public PlacementSystem placementSystem{ get; internal set; }
        public int buildingID { get; internal set; }
        public string buildingName { get; internal set; }
        
        protected override void Start()
        {
            base.Start();
            GetComponentInChildren<TextMeshProUGUI>().text = buildingName;
        }
        
        public void ClickHandler()
        {
            placementSystem.StartPlacement(buildingID);
        }
    }
}
