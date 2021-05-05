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
            panelLost.SetActive(true);
            Time.timeScale = 0;
            joystic.SetActive(false);
        }
    }
}
