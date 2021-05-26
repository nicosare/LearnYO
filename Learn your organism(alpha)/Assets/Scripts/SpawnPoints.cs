using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoints : MonoBehaviour
{
    public GameObject spawnPoint;
    public float timeBetweenSpawn;
    public int amount;
    private float fieldWidth;
    private float fieldHeight;
    public int spawnRange;
    public int destroyRange;
    public double safeZone;
    public GameObject field;
    void Start()
    {
        StartCoroutine(SpawnPoint());
        fieldWidth = field.transform.localScale.x;
        fieldHeight = field.transform.localScale.y;
    }

    private IEnumerator SpawnPoint()
    {
        int countSpawn = 0;
        while (true)
        {
            var spawnCenterPos = GameObject.FindGameObjectWithTag("Player").transform.position;
            var points = GameObject.FindGameObjectsWithTag(spawnPoint.tag);
            float xPos = Mathf.Clamp(Random.Range(spawnCenterPos.x - spawnRange, spawnCenterPos.x + spawnRange)
                , fieldWidth / 2 * -1, fieldWidth / 2);
            float yPos = Mathf.Clamp(Random.Range(spawnCenterPos.y - spawnRange, spawnCenterPos.y + spawnRange)
                , fieldHeight / 2 * -1, fieldHeight / 2);
            float zPos = spawnPoint.tag == "Enemy" ? -3 : -1;
            if ((xPos > spawnCenterPos.x + safeZone || xPos < spawnCenterPos.x - safeZone ||
                yPos > spawnCenterPos.y + safeZone || yPos < spawnCenterPos.y - safeZone) &&
                countSpawn < amount)
            {
                Instantiate(spawnPoint, new Vector3(xPos, yPos, zPos), Quaternion.identity);
                countSpawn++;
            }
            foreach (var p in points)
            {
                var distance = (p.transform.position - GameObject.FindGameObjectWithTag("Player").transform.position).magnitude;
                if (distance > destroyRange)
                {
                    Destroy(p);
                    countSpawn--;
                }
            }
            yield return new WaitForSeconds(timeBetweenSpawn);
        }
    }
}
