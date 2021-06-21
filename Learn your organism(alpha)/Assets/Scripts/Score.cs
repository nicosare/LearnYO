using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public GameObject shield;
    public GameObject scoreText;
    private int score;
    private int target;
    public GameObject panelWin;
    public GameObject joystic;
    public GameObject notification;
    private int firstMutation;
    private int secondMutation;
    private int thirdMutation;
    private bool isSelected;
    private int rndMutation;

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
            firstMutation = Random.Range(0, 5);
            secondMutation = Random.Range(5, 10);
            thirdMutation = Random.Range(10, 15);
        }
        if (collisison.gameObject.CompareTag("Point"))
        {
            Count();
            Mutation(firstMutation, secondMutation, thirdMutation);
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

    public void Mutation(int firstMutation, int secondMutation, int thirdMutation)
    {
        if (score == firstMutation || score == secondMutation || score == thirdMutation)
        {
            SetMutation();
            StartCoroutine(onWaiterOffNotification());
        }
    }

    public void SetMutation()
    {
        if (shield.activeSelf)
            rndMutation = Random.Range(0, 2);
        else
            rndMutation = Random.Range(0, 3);

        if (rndMutation == 0)
        {
            this.GetComponent<PlayerMove>().Speed *= 1.3f;
        }
        if (rndMutation == 1)
        {
            this.GetComponent<Transform>().localScale *= 1.3f;
        }
        if (rndMutation == 2)
        {
            shield.SetActive(true);
        }
    }

    IEnumerator onWaiterOffNotification()
    {
        notification.SetActive(true);
        yield return new WaitForSeconds(2);
        notification.SetActive(false);
    }
}
