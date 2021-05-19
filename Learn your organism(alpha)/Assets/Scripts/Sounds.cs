using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{

    public AudioSource[] sounds;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collisison)
    {
        if (collisison.gameObject.CompareTag("Point"))
        {
            sounds[0].Play();
        }
        if (collisison.gameObject.CompareTag("Enemy"))
        {
            sounds[1].Play();
        }
    }
}
