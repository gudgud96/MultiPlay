using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimerController : MonoBehaviour
{
    public GameObject timer;
    private float _currentTime = 20f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        _currentTime = _currentTime - Time.deltaTime;
        TextMesh TimerText = timer.GetComponent<TextMesh>();
        TimerText.text = DisplayText(_currentTime);


        // Check if limit is reached
        if (_currentTime <= 0)
        {
            TimerText.text = DisplayText(0f);
        }
    }

    private string DisplayText(float currentTime)
    {
        string displayText = "";
        string timeLeft = currentTime.ToString();
        Debug.Log(currentTime);
        if (currentTime <= 0)
        {
            return "00:00";
        }

        if (timeLeft.Split('.')[0].Length < 2)
        {
            displayText = "0";
        }
        displayText = displayText + timeLeft.Split('.')[0] + ":" +
                      timeLeft.Split('.')[1].Substring(0, 2);      
        return displayText;
    }
}
