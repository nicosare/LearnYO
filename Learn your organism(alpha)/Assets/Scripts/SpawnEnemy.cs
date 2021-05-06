using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour


{
    public GameObject enemy;
    public float timeBetweenSpawn = 10;
    public int amount = 10;
    public GameObject field;
    private float fieldWidth;
    private float fieldHeight;
    public int range;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnPoint());
        fieldWidth = field.transform.localScale.x;
        fieldHeight = field.transform.localScale.y;
    }

    private IEnumerator SpawnPoint()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        int countSpawn = 0;
        while (countSpawn < amount)
        {
            var enemyes = GameObject.FindGameObjectsWithTag("Enemy");
            countSpawn++;
            float xPos = Mathf.Clamp(Random.Range(player.transform.position.x - range, player.transform.position.x + range), fieldWidth / 2 * -1, fieldWidth / 2);
            float yPos = Mathf.Clamp(Random.Range(player.transform.position.y - range, player.transform.position.y + range), fieldHeight / 2 * -1, fieldHeight / 2);
            Instantiate(enemy, new Vector3(xPos, yPos, -1), Quaternion.identity);
            foreach (var e in enemyes)
            {
                var distance = (e.transform.position - player.transform.position).magnitude;
                if (distance > 8)
                {
                    Destroy(e);
                    countSpawn--;
                }
            }
            yield return new WaitForSeconds(timeBetweenSpawn);
        }
    }
}
