using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceGatherer : MonoBehaviour, IGatherable {
    public int carryingCapacity = 100;
    [SerializeField] private int currentCarryingAmount = 0;
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
    public void DepositResources(IResourceStorage storage) {
        if (currentCarryingAmount > 0) {
            storage.AddResource(currentResourceType, currentCarryingAmount);
            currentCarryingAmount = 0; // Reset gatherer's carried resources
        }
    }
}

