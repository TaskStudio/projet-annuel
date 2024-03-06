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
    public ResourceStorage FindNearestResourceStorage(Vector3 position) 
    {
        ResourceStorage[] allResourceStorage = FindObjectsOfType<ResourceStorage>();
        ResourceStorage nearestResourceStorage = null;
        float nearestDistance = float.MaxValue;

        foreach (ResourceStorage node in allResourceStorage)
        {
            float distance = Vector3.Distance(position, node.transform.position);
            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                nearestResourceStorage = node;
            }
        }

        return nearestResourceStorage;
    }
}