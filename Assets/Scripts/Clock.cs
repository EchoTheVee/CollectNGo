using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Clock : MonoBehaviour
{
    public int startTime;
    public int time;
    public bool isRunning;
    public TextMeshProUGUI clockDisplay;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CountDown());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CountDown()
    {
        yield return new WaitForSeconds(1);
        
        if (isRunning)
        {
            time--;
            UpdateDisplay();

            if (time <= 0)
            {
                TimerDone();
            }

        }

        StartCoroutine(CountDown());
    }

    public void TimerDone()
    {
        isRunning = false;
        Debug.Log("Timer Done :3");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void UpdateDisplay()
    {
        clockDisplay.text = time.ToString();
    }

    public void ChangeTime(int timeToAdd)
    {
        time += timeToAdd;
    }

    public void ToggleTimer()
    {
        isRunning = !isRunning;
    }

    public void ResetTime()
    {
        time = startTime;
    }
}
