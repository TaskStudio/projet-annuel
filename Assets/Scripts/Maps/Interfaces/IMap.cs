using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maps.Interfaces
{
    public class IMap : MonoBehaviour
    {
         IZone AllianceZone { get; }
         IZone MonsterZone { get; }
    }
}


