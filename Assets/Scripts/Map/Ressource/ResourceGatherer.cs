using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceGatherer : MonoBehaviour, IGatherable {
    public int carryingCapacity = 100;
    private int currentCarryingAmount = 0;
    public ResourceNode.ResourceType currentResourceType;

    void OnEnable() {
        ResourceGathererManager.Instance.RegisterGatherer(this);
    }

    void OnDisable() {
        ResourceGathererManager.Instance.UnregisterGatherer(this);
    }

    public void GatherResources(ResourceNode resourceNode) {
        if (currentCarryingAmount < carryingCapacity) {
            int amountToGather = Mathf.Min(carryingCapacity - currentCarryingAmount, resourceNode.resourceAmount);
            currentCarryingAmount += resourceNode.GatherResource(amountToGather);
            currentResourceType = resourceNode.resourceType;
        }
    }
}

