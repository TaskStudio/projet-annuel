using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceGatherer : MonoBehaviour, IGatherable {
    public int carryingCapacity = 100;
    [SerializeField] private int currentCarryingAmount = 0;
    public ResourceNode.ResourceType currentResourceType;
    public float gatherThresholdDistance = 5.0f;
    private Transform currentTarget;
    private ResourceNode currentResourceNode;
    private ResourceStorage currentResourceStorage;

    void Update()
    {
        // Check if we have a target and act accordingly
        if (currentTarget != null)
        {
            float distanceToTarget = Vector3.Distance(transform.position, currentTarget.position);
            if (distanceToTarget <= gatherThresholdDistance)
            {
                // Check and perform the appropriate action based on the target type
                if (currentResourceNode != null)
                {
                    GatherResources(currentResourceNode);
                    // Clear the target after gathering to prevent repeated gathering on each frame
                    ClearCurrentTarget();
                }
                else if (currentResourceStorage != null)
                {
                    DepositResources(currentResourceStorage);
                    // Clear the target after depositing
                    ClearCurrentTarget();
                }
            }
        }
    }

    public void SetTargetResourceNode(ResourceNode resourceNode)
    {
        currentResourceNode = resourceNode;
        currentResourceStorage = null; // Ensure storage is null when targeting a node
        currentTarget = resourceNode.transform;
    }

    public void SetTargetResourceStorage(ResourceStorage resourceStorage)
    {
        currentResourceStorage = resourceStorage;
        currentResourceNode = null; // Ensure node is null when targeting storage
        currentTarget = resourceStorage.transform;
    }

    private void ClearCurrentTarget()
    {
        currentTarget = null;
        currentResourceNode = null;
        currentResourceStorage = null;
    }
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
            // currentResourceNode = resourceNode;
            // currentRessourceStorage = ResourceGathererManager.Instance.FindNearestResourceStorage(this.transform.position);

        }
    }

    public void DepositResources(IResourceStorage storage) {
        if (currentCarryingAmount > 0) {
            storage.AddResource(currentResourceType, currentCarryingAmount);
            currentCarryingAmount = 0; // Reset gatherer's carried resources
        }
    }
}

