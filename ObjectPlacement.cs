using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacement : MonoBehaviour
{
    public GameObject objectPrefab;
    public int numObjects = 50;
    public Vector3 spawnArea = new Vector3(10f, 0f, 10f);

    private void Start()
    {
        PlaceObjects();
    }

    private void PlaceObjects()
    {
        for (int i = 0; i < numObjects; i++)
        {
            Vector3 spawnPosition = GetRandomSpawnPosition();
            Quaternion spawnRotation = Quaternion.Euler(0f, Random.Range(0f, 360f), 0f);
            Instantiate(objectPrefab, spawnPosition, spawnRotation);
        }
    }

    private Vector3 GetRandomSpawnPosition()
    {
        Vector3 center = transform.position;
        Vector3 randomPoint = center + new Vector3(
            Random.Range(-spawnArea.x / 2, spawnArea.x / 2),
            0f,
            Random.Range(-spawnArea.z / 2, spawnArea.z / 2)
        );
        return randomPoint;
    }
}
