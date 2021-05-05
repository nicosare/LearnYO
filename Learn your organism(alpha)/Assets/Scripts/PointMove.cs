using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointMove : MonoBehaviour
{
    public GameObject pointToMove;
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;
    public float Speed = 1f;
    bool isExists = false;
    private GameObject point;

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectWidth = pointToMove.transform.GetComponent<SpriteRenderer>().bounds.extents.x;
        objectHeight = pointToMove.transform.GetComponent<SpriteRenderer>().bounds.extents.y;
    }

    private void SpawnPoint()
    {
        if (!isExists)
        {
            isExists = true;
            float xPos = Random.Range(screenBounds.x * -1 + objectWidth, screenBounds.x - objectWidth);
            float yPos = Random.Range(screenBounds.y * -1 + objectHeight, screenBounds.y - objectHeight);
            point = Instantiate(pointToMove, new Vector3(xPos, yPos, -1), Quaternion.identity);
        }
    }
    void Update()
    {
        SpawnPoint();
        Vector3 positionPoint = point.transform.position;

        if (transform.position.y > positionPoint.y)
        {
            Vector2 move = (new Vector2(0, -1) * Time.deltaTime) * Speed;
            transform.Translate(move);
        }
        else if (transform.position.y <= positionPoint.y)
        {
            Vector2 move = (new Vector2(0, 1) * Time.deltaTime) * Speed;
            transform.Translate(move);
        }

        if (transform.position.x > positionPoint.x)
        {
            Vector2 move = (new Vector2(-1, 0) * Time.deltaTime) * Speed;
            transform.Translate(move);
        }
        else if (transform.position.x < positionPoint.x)
        {
            Vector2 move = (new Vector2(1, 0) * Time.deltaTime) * Speed;
            transform.Translate(move);
        }
    }

    private void OnCollisionEnter2D(Collision2D collisison)
    {
        if (collisison.gameObject.CompareTag("PointToMove"))
        {
            Destroy(point);
            isExists = false;
        }
        else if (collisison.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            Destroy(point);
        }
    }
}
