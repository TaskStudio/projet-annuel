using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceGathererManager : MonoBehaviour {
    public static ResourceGathererManager Instance { get; private set; }
    private List<ResourceGatherer> gatherers = new List<ResourceGatherer>();

    private void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
        } else {
            Instance = this;
        }
    }

    public void RegisterGatherer(ResourceGatherer gatherer) {
        if (!gatherers.Contains(gatherer)) {
            gatherers.Add(gatherer);
        }
    }

    public void UnregisterGatherer(ResourceGatherer gatherer) {
        if (gatherers.Contains(gatherer)) {
            gatherers.Remove(gatherer);
        }
    }

    // Example functionality: Find the nearest resource node for a gatherer
    public ResourceNode FindNearestResourceNode(Vector3 position, ResourceNode.ResourceType resourceType) {
        ResourceNode[] allNodes = FindObjectsOfType<ResourceNode>();
        ResourceNode nearestNode = null;
        float nearestDistance = float.MaxValue;

        foreach (ResourceNode node in allNodes) {
            if (node.resourceType == resourceType) {
                float distance = Vector3.Distance(position, node.transform.position);
                if (distance < nearestDistance) {
                    nearestDistance = distance;
                    nearestNode = node;
                }
            }
        }

        return nearestNode;
    }
}