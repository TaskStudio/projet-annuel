using UnityEngine;

public interface IMovementStrategy
{
    void MoveTo(Vector3 destination);
    bool IsAtDestination(Vector3 destination);
}
