public class GatheringResourceState : IState
{
    public void EnterState(ResourceGatherer gatherer)
    {
        // Attempt to get the closest resource node
        ResourceNode node = gatherer.GetCurrentResourceNode();
        if (node != null)
        {
            // If a node is found, move towards it
            gatherer.MoveToTarget(node.transform.position);
        }
        else
        {
            // If no nodes are found, maybe transition back to searching
            gatherer.TransitionToState(gatherer.searchingForResourceState);
        }
    }

    public void UpdateState(ResourceGatherer gatherer)
    {
        ResourceNode node = gatherer.GetCurrentResourceNode();
        if (node != null && gatherer.IsAtDestination(node.transform.position))
        {
            gatherer.GatherResources(node);
        }
    }

}