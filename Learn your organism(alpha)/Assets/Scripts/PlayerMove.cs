using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public bl_Joystick Joystick;
    public float Speed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float y = Joystick.Vertical;
        float x = Joystick.Horizontal;

        Vector2 move = (new Vector2(x, y) * Time.deltaTime) * Speed;
        transform.Translate(move);
        BorderMove();
    }

    private void BorderMove()
    {
        var objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x;
        var objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y;
        var pos = transform.position;
        if (pos.x > 50 - objectWidth)
            pos.x = 50 - objectWidth;
        if (pos.x < -50 + objectWidth)
            pos.x = -50 + objectWidth;
        if (pos.y > 50 - objectHeight)
            pos.y = 50 - objectHeight;
        if (pos.y < -50 + objectHeight)
            pos.y = -50 + objectHeight;
        transform.position = pos;
    }
}
