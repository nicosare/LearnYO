using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead : MonoBehaviour
{
    public GameObject panelLost;
    public GameObject joystic;

    private void OnCollisionEnter2D(Collision2D collisison)
    {
        if (collisison.gameObject.CompareTag("Enemy"))
        {
            if (GameObject.FindGameObjectsWithTag("Player").Length == 1)
            {
                panelLost.SetActive(true);
                Time.timeScale = 0;
                joystic.SetActive(false);
            }
            else
            {
                gameObject.SetActive(false);
                if (!gameObject.activeSelf)
                    Camera2DFollowTDS.FindPlayer();
                Destroy(gameObject,1);
            }
        }
    }
}
