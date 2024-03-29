using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    private int hp = 1000;
    
    public void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}