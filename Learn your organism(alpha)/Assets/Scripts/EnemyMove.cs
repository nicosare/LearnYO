using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float Speed = 0.5f;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 positionPlayer = Player.transform.position;

        if (transform.position.x > positionPlayer.x)
        {
            Vector2 move = (new Vector2(-1, 0) * Time.deltaTime) * Speed;
            transform.Translate(move);
        }
        else if (transform.position.x < positionPlayer.x)
        {
            Vector2 move = (new Vector2(1, 0) * Time.deltaTime) * Speed;
            transform.Translate(move);
        }

        if (transform.position.y > positionPlayer.y)
        {
            Vector2 move = (new Vector2(0, -1) * Time.deltaTime) * Speed;
            transform.Translate(move);
        }
        else if (transform.position.y < positionPlayer.y)
        {
            Vector2 move = (new Vector2(0, 1) * Time.deltaTime) * Speed;
            transform.Translate(move);
        }
    }
}
