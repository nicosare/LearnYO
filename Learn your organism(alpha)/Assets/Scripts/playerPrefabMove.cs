using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerPrefabMove : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject panelWin;
    public GameObject joystic;
    public  static int amount;
    private double eatCount;

    // Start is called before the first frame update
    void Start()
    {
        amount = 10;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private Vector3 GetPos(Vector3 pos)
    {
        var posX = Random.Range(gameObject.transform.position.x - 0.05f, gameObject.transform.position.x + 0.05f);
        var posY = Random.Range(gameObject.transform.position.y - 0.05f, gameObject.transform.position.y + 0.05f);
        var posZ = gameObject.transform.position.z;
        return new Vector3(posX, posY, posZ);
    }

    private void OnCollisionEnter2D(Collision2D collisison)
    {
        var playerCount = GameObject.FindGameObjectsWithTag("Player").Length;
        if (collisison.gameObject.CompareTag("Point") && playerCount < amount)
        {
            gameObject.transform.localScale *= 1.1f;
            eatCount++;
            if (eatCount % 3 == 0)
            {
                gameObject.transform.localScale /= Mathf.Pow(1.1f, 3);
                Instantiate(playerPrefab, GetPos(gameObject.transform.position), Quaternion.identity);
            }
        }
        if (playerCount == amount)
        {
            panelWin.SetActive(true);
            Time.timeScale = 0;
            joystic.SetActive(false);
        }

    }
}
