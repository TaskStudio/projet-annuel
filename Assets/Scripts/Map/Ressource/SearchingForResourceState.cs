
using UnityEngine;

public class SearchingForResourceState : IState
{
    public void EnterState(ResourceGatherer gatherer)
    {
        GameObject closestNode = gatherer.FindClosestTaggedObject("ResourceNode");
        if (closestNode != null)
            gatherer.MoveToTarget(closestNode.transform.position);
    }

    public void UpdateState(ResourceGatherer gatherer)
    {
        GameObject closestNode = gatherer.FindClosestTaggedObject("ResourceNode");
        if (closestNode != null && gatherer.IsAtDestination(closestNode.transform.position))
        {
            gatherer.TransitionToState(gatherer.gatheringResourceState);
        }
    }

}