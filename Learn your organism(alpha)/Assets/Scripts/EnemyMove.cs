using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float Speed;
    public Sprite[] sprites;
    public GameObject pointToMove;
    public double visibilityZone;
    private GameObject point;
    bool isExists = false;
    public float range;
    private float fieldWidth;
    private float fieldHeight;
    public GameObject field;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, 4)];
        fieldWidth = field.transform.localScale.x;
        fieldHeight = field.transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 positionPlayer = GameObject.FindGameObjectWithTag("Player").transform.position;

        var distance = (transform.position - positionPlayer).magnitude;
        if (distance < visibilityZone)
            MoveTo(positionPlayer);
        else
        {
            SpawnPoint();
            Vector3 positionPoint = point.transform.position;
            MoveTo(positionPoint);
        }

    }

    private void MoveTo(Vector3 positionPoint)
    {
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
    private void OnCollisionEnter2D(Collision2D collisison)
    {
        if (collisison.gameObject.CompareTag("PointToMove") || 
            collisison.gameObject.CompareTag("Enemy") || 
            collisison.gameObject.CompareTag("Point"))
        {
            Destroy(point);
            isExists = false;
        }
    }

}
