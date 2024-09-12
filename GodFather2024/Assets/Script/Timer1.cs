using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Timer1 : MonoBehaviour
{
    [SerializeField] private float timeRemaining = 10f;
    [SerializeField] private Text timerObject;
    [HideInInspector] public bool timerIsRunning = false;
    private string timeText;
    
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
