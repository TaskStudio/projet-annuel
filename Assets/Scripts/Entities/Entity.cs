using UnityEngine;

public class Entity : MonoBehaviour
{
    protected virtual void Awake()
    {
        EntityManager.Instance.RegisterEntity(this);
    }

    protected virtual void OnDestroy()
    {
        EntityManager.Instance.UnregisterEntity(this);
    }
}