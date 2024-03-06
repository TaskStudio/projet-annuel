using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp = 100;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Entity"))
        {
            Entity entity = collision.gameObject.GetComponent<Entity>();
            if (entity != null)
            {
                entity.TakeDamage(100);
            }
            
            Destroy(this.gameObject);
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