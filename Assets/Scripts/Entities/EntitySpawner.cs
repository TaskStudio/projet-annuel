using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySpawner : MonoBehaviour {
    public GameObject entityPrefab;
    public float spawnDelay = 2f;
    private Queue<int> spawnQueue = new Queue<int>();
    private bool isSpawning = false;
    public int entitiesPerRow = 5;
    public float spacing = 1f; 
    private List<Vector3> spawnedPositions = new List<Vector3>();

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            spawnQueue.Enqueue(1);
            if (!isSpawning) {
                StartCoroutine(ProcessSpawnQueue());
            }
        }
    }

    IEnumerator ProcessSpawnQueue() {
        isSpawning = true;
        while (spawnQueue.Count > 0) {
            spawnQueue.Dequeue();
            FindAndSpawnEntity();
            yield return new WaitForSeconds(spawnDelay);
        }
        isSpawning = false;
    }

    void FindAndSpawnEntity() {
        for (int i = 0; ; i++) {
            int row = i / entitiesPerRow;
            int col = i % entitiesPerRow;
            Vector3 spawnPosition = CalculateSpawnPosition(col, row);
            
            if (!Physics.CheckSphere(spawnPosition, 0.5f)) {
                Instantiate(entityPrefab, spawnPosition, Quaternion.identity);
                spawnedPositions.Add(spawnPosition);
                break; 
            }
        }
    }

    Vector3 CalculateSpawnPosition(int col, int row) {
        Vector3 position = new Vector3(
            col * spacing,
            1,
            row * spacing
        );

        position.x -= (entitiesPerRow - 1) * spacing / 2;
        position.z -= (entitiesPerRow - 1) * spacing / 2;
        return position;
    }
}