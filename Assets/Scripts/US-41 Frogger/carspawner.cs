using UnityEngine;

public class carspawner : MonoBehaviour
{
    public float spawnTimer = .3f;

    float nextTimeToSpawn = 0f;
	
	float timeOfLastMedianCarSpawn = -5f;

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
        float currentTime = Time.time;
		
		if (random == 2 && currentTime - timeOfLastMedianCarSpawn < 10)
		{
			return;
		}
        Transform spawnPoint = spawnPoints[random];
	
        Instantiate(car, spawnPoint.position, spawnPoint.rotation);

		if (random == 2) {
			timeOfLastMedianCarSpawn = currentTime;
		}
   }
}
