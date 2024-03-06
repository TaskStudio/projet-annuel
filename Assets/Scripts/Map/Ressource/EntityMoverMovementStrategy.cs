using UnityEngine;

public class EntityMoverMovementStrategy : IMovementStrategy
{
    private EntityMover entityMover;

    public EntityMoverMovementStrategy(EntityMover entityMover)
    {
        this.entityMover = entityMover;
    }

    public void MoveTo(Vector3 destination)
    {
        entityMover.SetTargetPosition(destination);
    }

    public bool IsAtDestination(Vector3 destination)
    {
        // Simplistic check, consider refining based on actual use cases
        return !entityMover.IsMoving && Vector3.Distance(entityMover.transform.position, destination) < 0.5f;
    }
}

