using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoints : MonoBehaviour
{
    public GameObject pointsPrefab;
    public int timeBetweenSpawn = 5;
    public int amount = 1000;
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;

    void Start()
    {
        StartCoroutine(SpawnPoint());
        objectWidth = pointsPrefab.transform.GetComponent<SpriteRenderer>().bounds.extents.x;
        objectHeight = pointsPrefab.transform.GetComponent<SpriteRenderer>().bounds.extents.y;
    }

    private IEnumerator SpawnPoint()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        int countSpawn = 0;
        while (countSpawn < amount)
        {
            countSpawn ++;
            float xPos = Random.Range(screenBounds.x * -1 + objectWidth, screenBounds.x - objectWidth);
            float yPos = Random.Range(screenBounds.y * -1 + objectHeight, screenBounds.y - objectHeight);
            Instantiate(pointsPrefab, new Vector3(xPos, yPos, -1), Quaternion.identity);

            yield return new WaitForSeconds(timeBetweenSpawn);
        }
    }
}
