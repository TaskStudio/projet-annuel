using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Construction
{
    [System.Serializable]
    public class Building : MonoBehaviour
    {
        public Vector2Int gridPosition { get; internal set; }
        public StateEnum state { get; internal set; }

        public enum StateEnum
        {
            Preview,
            Constructing,
            Constructed,
        }
    }
}
