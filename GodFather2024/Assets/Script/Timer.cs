using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Timer : MonoBehaviour
{
    [SerializeField] private float timeRemaining = 10f;
    [SerializeField] private float timePopUp = 5f;
    [SerializeField] private TMP_Text timerObject;
    [SerializeField] private GameObject popUp;
    [HideInInspector] public bool timerIsRunning = false;
    private string timeText;
    private bool canPopUp = true;

    private void Awake()
    {
        popUp.SetActive(false);
    }
    void Start()
    {
        timerIsRunning = true;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
            }

            if (timeRemaining < timePopUp && canPopUp)
            {
                popUp.SetActive(true);
                canPopUp = false;
            }
        }

    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText = string.Format("{0:00}:{1:00}", minutes, seconds);

        timerObject.text = timeText;
    }
}