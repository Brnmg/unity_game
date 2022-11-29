using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeLeft = -1;
    public bool timerOn = false;

    public TMP_Text timerText;

    // Start is called before the first frame update
    void Start()
    {
        timerOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerOn)
        {
            if (timeLeft < 120)
            {
                timeLeft += Time.deltaTime;
                UpdateTimer(timeLeft);
            }
            else
            {
                timeLeft = 0;
                timerOn = false;
            }
        }
    }

    void UpdateTimer(float currentTime)
    {
        currentTime += 1;

        float seconds = Mathf.FloorToInt(currentTime % 60);

        timerText.text = seconds.ToString();
    }
}
