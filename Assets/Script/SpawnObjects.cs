using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public static ObjectSpawner Instance { get; private set; }

    [SerializeField] private GameObject[] spawnPrefabs;
    [SerializeField] private Transform[] spawnLocations;

    public bool IsSpawning { get; private set; } = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void StartSpawning()
    {
        if (IsSpawning) return;

        IsSpawning = true;
        InvokeRepeating(nameof(SpawnObject), 2f, 3f);
    }

    private void SpawnObject()
    {
        if (spawnPrefabs.Length == 0 || spawnLocations.Length == 0) return;

        int prefabIndex = Random.Range(0, spawnPrefabs.Length);
        int locationIndex = Random.Range(0, spawnLocations.Length);

        Instantiate(spawnPrefabs[prefabIndex], spawnLocations[locationIndex].position, Quaternion.identity);
    }

    public void StopSpawning()
    {
        if (!IsSpawning) return;

        IsSpawning = false;
        CancelInvoke(nameof(SpawnObject));
    }
}
