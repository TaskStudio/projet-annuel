using UnityEngine;

public class EntitySpawner : MonoBehaviour {
    public GameObject entityPrefab; 
    
    void Start() {
        
        Vector3 startPosition = new Vector3(0, 1, 0); 
        SpawnEntity(startPosition);
    }
    
    void Update() {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 randomPosition = new Vector3(Random.Range(-10, 10), 1, Random.Range(-10, 10)); // Set y to 1
            SpawnEntity(randomPosition);
        }
    }

    void SpawnEntity(Vector3 position) {
        Instantiate(entityPrefab, position, Quaternion.identity);
    }
}