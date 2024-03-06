using UnityEngine;
using UnityEngine.AI;

public class NavMeshAgentMovementStrategy : IMovementStrategy
{
    private NavMeshAgent agent;

    public NavMeshAgentMovementStrategy(NavMeshAgent agent)
    {
        this.agent = agent;
    }

    public void MoveTo(Vector3 destination)
    {
        agent.SetDestination(destination);
    }

    public bool IsAtDestination(Vector3 destination)
    {
        return !agent.pathPending && agent.remainingDistance <= agent.stoppingDistance && agent.remainingDistance != Mathf.Infinity;
    }
}
