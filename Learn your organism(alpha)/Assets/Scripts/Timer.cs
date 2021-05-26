using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public GameObject timeText;
    public float timer;
    public GameObject panelLost;
    public GameObject joystic;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        timeText.GetComponent<Text>().text = 
            "Времени осталось: " + Mathf.Round(timer).ToString() + "\n" + 
            "Количество клеток: " + GameObject.FindGameObjectsWithTag("Player").Length +"/" +playerPrefabMove.amount;
        if (timer <= 0)
        {
            panelLost.SetActive(true);
            Time.timeScale = 0;
            joystic.SetActive(false);
        }
    }
}
