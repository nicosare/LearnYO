using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointMove : MonoBehaviour
{
    public GameObject pointToMove;
    public float Speed = 1f;
    bool isExists = false;
    private GameObject point;
    public int range;
    private float fieldWidth;
    private float fieldHeight;
    public GameObject field;

    void Start()
    {
        fieldWidth = field.transform.localScale.x;
        fieldHeight = field.transform.localScale.y;
    }

    private void SpawnPoint()
    {
        if (!isExists)
        {
            isExists = true;
            float xPos = Mathf.Clamp(Random.Range(transform.position.x - range, transform.position.x + range), fieldWidth / 2 * -1, fieldWidth / 2);
            float yPos = Mathf.Clamp(Random.Range(transform.position.y - range, transform.position.y + range), fieldHeight / 2 * -1, fieldHeight / 2);

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
        if (collisison.gameObject.CompareTag("PointToMove")
            || collisison.gameObject.CompareTag("Point")
            || collisison.gameObject.CompareTag("Enemy"))
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
