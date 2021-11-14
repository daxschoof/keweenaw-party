using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    public float spawnTimer = 1f;

    float nextTimeToSpawn = 0f;

    public GameObject tile;

    public Transform[] spawnPoints;


    void FixedUpdate()
    {
        if (nextTimeToSpawn <= Time.time)
        {
            SpawnTile();
            nextTimeToSpawn = Time.time + spawnTimer;
        }
    }
    void SpawnTile()
    {
        int random = Random.Range(0, spawnPoints.Length);
        float currentTime = Time.time;

        Transform spawnPoint = spawnPoints[random];

        Instantiate(tile, spawnPoint.position, spawnPoint.rotation);
    }
}
