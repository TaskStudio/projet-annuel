using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySpawner : MonoBehaviour {
    public GameObject entityPrefab; // Exposed in Unity Editor
    
    void Start() {
        // Spawns one entity automatically at the start
        Vector3 startPosition = new Vector3(0, 1, 0); // You can change this start position as needed
        SpawnEntity(startPosition);
    }
    
    void Update() {
        // Spawn an entity at a random position when the space key is pressed
        if (Input.GetKeyDown(KeyCode.Space)) {
            Vector3 randomPosition = new Vector3(Random.Range(-10, 10), 1, Random.Range(-10, 10));
            SpawnEntity(randomPosition);
        }
    }

    void SpawnEntity(Vector3 position) {
        Instantiate(entityPrefab, position, Quaternion.identity);
    }
}