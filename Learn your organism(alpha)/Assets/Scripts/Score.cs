using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public GameObject scoreText;
    private int score;
    private int target;
    public GameObject panelWin;
    public GameObject joystic;
    public GameObject notification;

    void Start()
    {
        score = 0;
        target = 10;
    }

    private void OnCollisionEnter2D(Collision2D collisison)
    {
        if (collisison.gameObject.CompareTag("Point"))
        {
            Count();
            Mutation();
        }
    }

    public void Count()
    {
        score++;
        scoreText.GetComponent<Text>().text = "Score " + score.ToString();

        if (score == target)
        {
            panelWin.SetActive(true);
            Time.timeScale = 0;
            joystic.SetActive(false);
        }
    }

    public void Mutation()
    {
        if (score == 3 || score == 6)
        {
            SetMutation();
            StartCoroutine(onWaiterOffNotification());
        }
    }

    public void SetMutation()
    {
        var rndMutation = Random.Range(0, 2);
        if (rndMutation == 0)
        {
            this.GetComponent<PlayerMove>().Speed *= 1.2f;
        }
        else
        {
            this.GetComponent<Transform>().localScale += new Vector3(0.2f, 0.2f, 0);
        }
    }

    IEnumerator onWaiterOffNotification()
    {
        notification.SetActive(true);
        yield return new WaitForSeconds(2);
        notification.SetActive(false);
    }
}
