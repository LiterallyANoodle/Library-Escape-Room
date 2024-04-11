using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Game : MonoBehaviour
{
    private float currCountdownValue;
    public float startTime = 120;
    public TextMeshProUGUI text;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartCountdown(startTime));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private string TimeToString()
    {
        string minutes = ((int)(currCountdownValue / 60)).ToString();
        if (minutes.Length == 1)
        {
            minutes = "0" + minutes;
        }

        string seconds = ((int)(currCountdownValue % 60)).ToString();
        if (seconds.Length == 1)
        {
            seconds = "0" + seconds;
        }

        return (minutes + ":" + seconds);
    }

    public IEnumerator StartCountdown(float countdownValue)
    {
        currCountdownValue = countdownValue;
        string timeText = TimeToString();
        text.text = timeText;
        while (currCountdownValue > 0)
        {
            yield return new WaitForSeconds(1.0f);
            currCountdownValue--;
            timeText = TimeToString();
            text.text = timeText;
        }
    }
}
