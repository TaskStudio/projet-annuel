using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceNode : MonoBehaviour {
    public enum ResourceType { Wood, Gold, Stone }
    public ResourceType resourceType;
    public int resourceAmount = 100;

    public int GatherResource(int amountRequested) {
        int amountGathered = Mathf.Min(amountRequested, resourceAmount);
        resourceAmount -= amountGathered;
        if (resourceAmount <= 0) {
            Destroy(gameObject); // Optionally remove the node when depleted
        }
        return amountGathered;
    }
}

