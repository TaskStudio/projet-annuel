using System.Collections;
using UnityEngine;

public class EntitySpawner : MonoBehaviour {
    public GameObject entityPrefab; 
    public float spawnDelay = 2f;
    private bool isSpawning = false;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space) && !isSpawning)
        {
            StartCoroutine(SpawnEntityWithDelay());
        }
    }

    IEnumerator SpawnEntityWithDelay() {
        isSpawning = true;
        while (true)
        {
            Vector3 randomPosition = new Vector3(Random.Range(-10, 10), 1, Random.Range(-10, 10));
            Instantiate(entityPrefab, randomPosition, Quaternion.identity);
            yield return new WaitForSeconds(spawnDelay);
        }
    }
}