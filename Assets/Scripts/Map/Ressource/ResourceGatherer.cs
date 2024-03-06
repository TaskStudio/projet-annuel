using UnityEngine;
using UnityEngine.AI;

public class ResourceGatherer : MonoBehaviour
{
    public int carryingCapacity = 100;
    private int currentCarryingAmount = 0;
    public ResourceNode.ResourceType currentResourceType;
    private IMovementStrategy movementStrategy;

    // State management
    public IState CurrentState { get; private set; }
    public SearchingForResourceState searchingForResourceState = new SearchingForResourceState();
    public GatheringResourceState gatheringResourceState = new GatheringResourceState();
    public ReturningToStorageState returningToStorageState = new ReturningToStorageState();
    public DepositingResourceState depositingResourceState = new DepositingResourceState();
    private EntityMover entityMover;
    private NavMeshAgent navMeshAgent;

    

    void Start()
    {
        var agent = GetComponent<NavMeshAgent>();
        SetMovementStrategy(new NavMeshAgentMovementStrategy(agent));
        TransitionToState(searchingForResourceState);
    }


    void Update()
    {
        CurrentState.UpdateState(this);
    }

    public void TransitionToState(IState newState)
    {
        CurrentState = newState;
        newState.EnterState(this);
    }

    public void MoveToTarget(Vector3 target)
    {
        movementStrategy.MoveTo(target);
    }

    public void SetMovementStrategy(IMovementStrategy strategy)
    {
        this.movementStrategy = strategy;
    }

    // The rest of your ResourceGatherer code remains unchanged

    public GameObject FindClosestTaggedObject(string tag)
    {
        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag(tag);
        GameObject closest = null;
        float closestDistance = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach (GameObject obj in taggedObjects)
        {
            Vector3 directionToTarget = obj.transform.position - currentPosition;
            float dSquared = directionToTarget.sqrMagnitude;
            if (dSquared < closestDistance)
            {
                closestDistance = dSquared;
                closest = obj;
            }
        }
        return closest;
    }

    public void GatherResources(ResourceNode node)
    {
        if (movementStrategy.IsAtDestination(node.transform.position) && currentCarryingAmount < carryingCapacity && node != null)
        {
            int gatherAmount = Mathf.Min(node.resourceAmount, carryingCapacity - currentCarryingAmount);
            currentCarryingAmount += gatherAmount;
            node.resourceAmount -= gatherAmount;
            currentResourceType = node.resourceType;

            if (currentCarryingAmount >= carryingCapacity || node.resourceAmount <= 0)
            {
                TransitionToState(returningToStorageState);
            }
        }
    }


    public void DepositResources(ResourceStorage storage)
    {
        // Assuming storage has a Transform or a method to get its position
        Vector3 storagePosition = storage.transform.position; 

        if (movementStrategy.IsAtDestination(storagePosition) && currentCarryingAmount > 0)
        {
            storage.AddResource(currentResourceType, currentCarryingAmount);
            currentCarryingAmount = 0;
            TransitionToState(searchingForResourceState);
        }
    }

    public ResourceNode GetCurrentResourceNode()
    {
        GameObject closestNodeObj = FindClosestTaggedObject("ResourceNode");
        if (closestNodeObj != null)
        {
            return closestNodeObj.GetComponent<ResourceNode>();
        }
        return null;
    }
    public void UseNavMeshForNavigation()
    {
        navMeshAgent.enabled = true; // Disable NavMeshAgent to use EntityMover
        SetMovementStrategy(new NavMeshAgentMovementStrategy(GetComponent<NavMeshAgent>()));
    }
    public bool IsAtDestination(Vector3 destination)
    {
        return movementStrategy.IsAtDestination(destination);
    }
    public void UseEntityMoverForNavigation()
    {
        navMeshAgent.enabled = false; // Disable NavMeshAgent to use EntityMover
        SetMovementStrategy(new EntityMoverMovementStrategy(GetComponent<EntityMover>()));
    }




}
