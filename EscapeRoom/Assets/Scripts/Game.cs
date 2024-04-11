using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Game : MonoBehaviour
{
    private float currCountdownValue;
    public float startTime = 120;
    public TextMeshProUGUI text;
    public PuzzleManager puzzleManager;
    public Menu menu;
    public GameObject portal;

    public bool win;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartCountdown(startTime));
        win = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (puzzleManager.VerifySolved())
        {
            portal.SetActive(true);
        }
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

    public void SetWin() { win = true; }

    public IEnumerator StartCountdown(float countdownValue)
    {
        currCountdownValue = countdownValue;
        string timeText = TimeToString();
        text.text = timeText;
        while (currCountdownValue > 0 && !win)
        {
            yield return new WaitForSeconds(1.0f);
            currCountdownValue--;
            timeText = TimeToString();
            text.text = timeText;
        }

        if (win)
        {
            menu.GameWin();
        }
        else
        {
            menu.GameOver();
        }
    }
}
