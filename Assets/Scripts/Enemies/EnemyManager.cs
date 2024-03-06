using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnDelay = 2f;
    public float moveSpeed = 5f;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            GameObject enemy = SpawnEnemy();
            StartCoroutine(MoveEnemyToClosestEntity(enemy));
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    private GameObject SpawnEnemy()
    {
        return Instantiate(enemyPrefab, new Vector3(0, 1, 0), Quaternion.identity);
    }

    private IEnumerator MoveEnemyToClosestEntity(GameObject enemy)
    {
        while (enemy != null)
        {
            Vector3 closestEntityPosition = FindClosestEntityPosition();
            
            if (!float.IsPositiveInfinity(closestEntityPosition.x))
            {
                enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, closestEntityPosition, moveSpeed * Time.deltaTime);
            }
        
            yield return null;
        }
    }

    private Vector3 FindClosestEntityPosition()
    {
        GameObject[] entities = GameObject.FindGameObjectsWithTag("Entity");
        
        if (entities.Length == 0)
        {
            return Vector3.positiveInfinity;
        }

        GameObject closestEntity = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = this.transform.position;

        foreach (GameObject entity in entities)
        {
            Vector3 directionToTarget = entity.transform.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                closestEntity = entity;
            }
        }

        if (closestEntity != null)
        {
            return closestEntity.transform.position;
        }
        
        return currentPosition;
    }
}
