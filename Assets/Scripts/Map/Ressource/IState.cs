using UnityEngine;

public interface IState
{
    void EnterState(ResourceGatherer gatherer);
    void UpdateState(ResourceGatherer gatherer);
}