using UnityEngine;

public class GathererSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject gathererPrefab;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            SpawnGatherer();
        }
    }

    public void SpawnGatherer()
    {
        Instantiate(gathererPrefab, transform.position, Quaternion.identity);
    }
}