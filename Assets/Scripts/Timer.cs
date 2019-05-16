using UnityEngine;

public class Timer : MonoBehaviour
{

    public TextMesh TimerText;
    public int MinTimer;
    public int MaxTimer;
    public int ClickThreshold;
    public bool ResetTimer;
    public bool GameOver;
    private float _currentTime;
    private bool _countingDown;

    // Start is called before the first frame update
    void Start()
    {
        TimerText = gameObject.GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameOver)
        {
            if (_countingDown)
            {
                // Update Timer
                _currentTime = _currentTime - Time.deltaTime;
                TimerText.text = DisplayText(_currentTime);
                
                // Check if limit is reached
                if (_currentTime <= 0)
                {
                    // Trigger lost game
                    GameOver = true;
                    _countingDown = false;

                    //TODO: This can be removed, but exists for demo purposes
                    TimerText.text = "Game \nOver!";
                }

                // Change color of textmesh to red if current time < threshold
#if UNITY_EDITOR
                if (_currentTime < ClickThreshold)
                {

                    TimerText.color = Color.red;
                    if (Input.GetKey(KeyCode.Space))
                    {
                        Debug.Log("Reset!");
                        ResetTimer = true;
                    }
                }
                else
                {
                    TimerText.color = Color.white;
                }
#endif
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
                if (_currentTime < ClickThreshold)
                {

                    TimerText.color = Color.red;
                    var touch = Input.GetTouch(0);
                    if (touch.position.x > Screen.width * 1 / 2 + 1)
                    {
                        Debug.Log("Reset!");
                        ResetTimer = true;
                    }
                }
                else
                {
                    TimerText.color = Color.white;
                }
#endif
            }
            else
            {
                _currentTime = Random.Range(MinTimer, MaxTimer);
                _countingDown = true;
            }
        }

        if (ResetTimer && _currentTime < ClickThreshold)
        {
            GameOver = false;
            _countingDown = false;
            ResetTimer = false;
        }
        else
        {
            ResetTimer = false;
        }
    }

    private string DisplayText(float currentTime)
    {
        string displayText = "";
        string timeLeft = currentTime.ToString();

        if (timeLeft.Split('.')[0].Length < 2)
        {
            displayText = "0";
        }

        displayText = displayText + timeLeft.Split('.')[0] + ":" + 
                      timeLeft.Split('.')[1].Substring(0, 2);
        
        return displayText;
    }
}
