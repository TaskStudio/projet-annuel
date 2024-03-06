using UnityEngine;

public class ReturningToStorageState : IState
{
    public void EnterState(ResourceGatherer gatherer)
    {
        GameObject closestStorage = gatherer.FindClosestTaggedObject("ResourceStorage");
        if (closestStorage != null)
        {
            gatherer.MoveToTarget(closestStorage.transform.position);
        }
    }

    public void UpdateState(ResourceGatherer gatherer)
    {
        GameObject closestStorage = gatherer.FindClosestTaggedObject("ResourceStorage");
        if (closestStorage != null && gatherer.IsAtDestination(closestStorage.transform.position))
        {
            ResourceStorage storage = closestStorage.GetComponent<ResourceStorage>();
            if (storage != null)
            {
                gatherer.DepositResources(storage);
            }
        }
    }


}