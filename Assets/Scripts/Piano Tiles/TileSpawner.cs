using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TileSpawner : MonoBehaviour
{
    float nextTimeToSpawn;
    public GameObject tile;
    public Transform[] spawnPoints;
    public static bool gamePlaying;
    private bool isFinished;
    private float timeStart;
    public GameObject endMenu;
    private Text result;

    double[] nextTimeToSpawnArray = {0.346, 0.679, 1.046, 1.384, 1.746, 2.101, 2.447, 
                            2.792, 3.106, 3.476, 3.826, 4.172, 4.517, 4.871, 5.221, 
                            5.586, 5.930, 6.291, 6.679, 7.047, 7.429, 7.789, 8.143, 
                            8.500, 8.848, 9.222, 9.580, 9.901, 10.232, 10.606, 10.952, 
                            11.339, 11.684, 12.047, 12.375, 12.720, 13.088, 13.437, 
                            13.783, 14.137, 14.465, 14.859, 15.213, 15.562, 15.865, 
                            16.205, 16.564, 16.914, 17.255, 17.620, 17.971, 18.330, 
                            18.699, 19.056, 19.413, 19.754, 20.104, 20.451, 20.787, 
                            21.152, 21.465, 21.847, 22.190, 22.565, 22.900, 23.259, 
                            23.580, 23.934, 24.254, 24.621, 24.993, 25.350, 25.706, 
                            26.042, 26.363, 26.717, 27.049, 27.405, 28.133, 28.460, 
                            28.791, 29.098, 29.424, 29.766, 30.076, 30.393, 30.726, 
                            31.088, 31.380, 31.694, 32.032, 32.332, 32.669, 32.972, 
                            33.291, 33.607, 33.903, 34.216, 34.542, 34.876, 35.180, 
                            35.475, 35.787, 36.099, 36.414, 36.716, 37.031, 37.339, 
                            37.654, 37.973, 38.270, 38.567, 38.882, 39.190, 39.514, 
                            39.800, 40.134, 40.855, 41.327, 41.881, 42.449, 42.949, 
                            43.450, 43.893, 44.304, 44.699, 45.121, 45.538, 45.881, 
                            46.221, 46.507, 46.808, 47.073, 47.376, 47.640, 47.914, 
                            48.132, 48.353, 48.586, 48.827, 49.049, 49.271, 49.499, 
                            49.739, 49.949, 50.148, 50.339, 50.565, 50.783, 50.998, 
                            51.203, 51.397, 51.593, 51.786, 51.981, 52.190, 52.398, 
                            53.248, 54.808, 55.731, 57.000, 58.000, 59.000, 60.000};
    private int n;

    void Start()
    {
        n = 0;
        Time.timeScale = 1;
        gamePlaying = true;
        isFinished = false;
        timeStart = Time.time;
        nextTimeToSpawn = 0.55f + timeStart;
        result = GameObject.Find("ResultText").GetComponent<Text>();
        endMenu.gameObject.SetActive(false);
        //Debug.Log(nextTimeToSpawnArray.Length);
    }

    void Update()
    {
        if (n == nextTimeToSpawnArray.Length - 1)
        {
            gamePlaying = false;
            isFinished = true;
        }

        if (gamePlaying)
        {
            if (nextTimeToSpawn <= Time.time)
            {
                SpawnTile();
                //Debug.Log(n);
                nextTimeToSpawn = (float)nextTimeToSpawnArray[n] + 0.55f + timeStart;
                n++;
            }

        }
        else
        {
            if (isFinished)
            {
                Time.timeScale = 0;
                result.text = "You finished the song! :)\n+" + PianoTilesScore.scoreValue + " points";
                endMenu.gameObject.SetActive(true);
                //Debug.Log("You won");
            }
            else
            {
                Time.timeScale = 0;
                result.text = "Good try! :)\n+" + PianoTilesScore.scoreValue + " points";
                endMenu.gameObject.SetActive(true);
            }
          
        }

    }

    IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
    }

    void SpawnTile()
    {
        int random = Random.Range(0, spawnPoints.Length);
        float currentTime = Time.time;

        Transform spawnPoint = spawnPoints[random];

        Instantiate(tile, spawnPoint.position, spawnPoint.rotation);
    }

    public void OnButtonLoadScene(string sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
