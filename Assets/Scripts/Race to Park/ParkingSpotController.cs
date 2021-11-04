using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkingSpotController : MonoBehaviour
{
    [SerializeField] private GameObject spotPrefab1;
    [SerializeField] private GameObject spotPrefab2;
    [SerializeField] private GameObject spotPrefab3;
    [SerializeField] private GameObject spotPrefab4;
    [SerializeField] private GameObject spotPrefab5;
    [SerializeField] private GameObject spotPrefab6;
    [SerializeField] private GameObject spotPrefab7;
    [SerializeField] private GameObject spotPrefab8;
    [SerializeField] private GameObject spotPrefab9;
    [SerializeField] private GameObject spotPrefab10;
    [SerializeField] private GameObject spotPrefab11;
    [SerializeField] private GameObject spotPrefab12;
    public GameObject parkingSpaces;
    public GameObject parkedCarPrefab;
    public GameObject emptySpacePrefab;
    public GameObject hiddenPrefab;

    void GenerateSpots(GameObject spotPrefab, int numOfSpots)
    {
        float x = spotPrefab.transform.position.x;
        float y = spotPrefab.transform.position.y;
        var hiddenBox = Instantiate(hiddenPrefab, new Vector3(x, y), Quaternion.identity);
        hiddenBox.name = $"{spotPrefab.name} - Hidden";
        hiddenBox.transform.parent = parkingSpaces.transform;

        for (float i = 1; i < numOfSpots; i++)
        {
            x += (float)0.426;
            int prob = Random.Range(0, 100);
            if (prob < 3)
            {
                var spawnedSpot = Instantiate(emptySpacePrefab, new Vector3(x, y), Quaternion.identity);
                spawnedSpot.name = $"{spotPrefab.name} {i}";
                spawnedSpot.transform.parent = parkingSpaces.transform;
            }
            else
            {
                var spawnedSpot = Instantiate(parkedCarPrefab, new Vector3(x, y), Quaternion.identity);
                spawnedSpot.name = $"{spotPrefab.name} {i}";
                spawnedSpot.transform.parent = parkingSpaces.transform;
            }
            hiddenBox = Instantiate(hiddenPrefab, new Vector3(x, y), Quaternion.identity);
            hiddenBox.name = $"{spotPrefab.name} {i} - Hidden";
            hiddenBox.transform.parent = parkingSpaces.transform;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        GenerateSpots(spotPrefab1, 15);
        GenerateSpots(spotPrefab2, 15);
        GenerateSpots(spotPrefab3, 15);
        GenerateSpots(spotPrefab4, 15);
        GenerateSpots(spotPrefab5, 7);
        GenerateSpots(spotPrefab6, 16);
        GenerateSpots(spotPrefab7, 16);
        GenerateSpots(spotPrefab8, 16);
        GenerateSpots(spotPrefab9, 16);
        GenerateSpots(spotPrefab10, 16);
        GenerateSpots(spotPrefab11, 16);
        GenerateSpots(spotPrefab12, 12);
    }

}
