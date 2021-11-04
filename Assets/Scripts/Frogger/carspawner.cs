using UnityEngine;

public class carspawner : MonoBehaviour
{
    public float spawnTimer = .3f;

    float nextTimeToSpawn = 0f;

    public GameObject car;

    public Transform[] spawnPoints;

    void FixedUpdate()
    {
        if (nextTimeToSpawn <= Time.time)
        {
            SpawnCar();
            nextTimeToSpawn = Time.time + spawnTimer;
        }
    }
   void SpawnCar()
   {
        int random = Random.Range(0, spawnPoints.Length);

        Transform spawnPoint = spawnPoints[random];

        Instantiate(car, spawnPoint.position, spawnPoint.rotation);
   }
}
