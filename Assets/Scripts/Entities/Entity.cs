using UnityEngine;

public class Entity : MonoBehaviour
{
    public int hp = 100;

    protected virtual void Awake()
    {
        if (EntityManager.Instance != null)
        {
            EntityManager.Instance.RegisterEntity(this);
        }
    }


    protected virtual void OnDestroy()
    {
        EntitiesController controller = FindObjectOfType<EntitiesController>();
        if (controller != null)
        {
            controller.DeregisterEntity(this.gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

}
