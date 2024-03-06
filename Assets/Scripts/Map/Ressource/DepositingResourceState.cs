using UnityEngine;

public class DepositingResourceState : IState
{
    public void EnterState(ResourceGatherer gatherer)
    {
        GameObject closestStorage = gatherer.FindClosestTaggedObject("ResourceStorage");
        if (closestStorage != null)
            gatherer.MoveToTarget(closestStorage.transform.position);
    }

    public void UpdateState(ResourceGatherer gatherer)
    {
        ResourceStorage storage = gatherer.FindClosestTaggedObject("ResourceStorage").GetComponent<ResourceStorage>();
        gatherer.DepositResources(storage);
    }
}