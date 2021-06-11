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
    private int firstMutation;
    private int secondMutation;
    private bool isSelected;

    void Start()
    {
        score = 0;
        target = 20;
        isSelected = false;
    }

    private void OnCollisionEnter2D(Collision2D collisison)
    {
        if (!isSelected)
        {
            firstMutation = Random.Range(0, 7);
            secondMutation = Random.Range(7, 15);
        }
        if (collisison.gameObject.CompareTag("Point"))
        {
            Count();
            Mutation(firstMutation, secondMutation);
            isSelected = true;
        }
    }

    public void Count()
    {
        score++;
        scoreText.GetComponent<Text>().text = "Счёт: " + score.ToString() + "/" + target;

        if (score == target)
        {
            panelWin.SetActive(true);
            Time.timeScale = 0;
            joystic.SetActive(false);
        }
    }

    public void Mutation(int firstMutation, int secondMutation)
    {
        if (score == firstMutation || score == secondMutation)
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
            this.GetComponent<PlayerMove>().Speed *= 1.3f;
        }
        else
        {
            this.GetComponent<Transform>().localScale *= 1.3f;
        }
    }

    IEnumerator onWaiterOffNotification()
    {
        notification.SetActive(true);
        yield return new WaitForSeconds(2);
        notification.SetActive(false);
    }
}
