using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetNextLevels : MonoBehaviour
{
    public GameObject level2Info;
    // Update is called once per frame
    void Update()
    {
        if (StaticHolder.IsNextLevel)
        {
            level2Info.SetActive(true);
            GameObject.Find("MainMenu").SetActive(false);
            StaticHolder.IsNextLevel = false;
        }
    }
}
