using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int hp = 1000;
    
    public void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}