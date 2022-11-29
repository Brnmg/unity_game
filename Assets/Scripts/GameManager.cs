using TMPro;
using UnityEngine;
using System.Linq;


public class GameManager : MonoBehaviour
{
    public PlayerController player; 

    public GameObject playButton;
    public GameObject gameOver;
    public GameObject panel;
    public GameObject helpButton;

    public TMP_Text scoreText;
    public TMP_Text title;
    public TMP_Text timerText;

    public Material material;
    public Renderer background;

    private int score;

    public float timeLeft;
    public bool timerOn = false;
    public bool changeBackground = true;

    public void Awake()
    {
        scoreText.enabled = false;
        timerOn = true;

        gameOver.SetActive(false);
        panel.SetActive(false);
        
        Pause();

        Application.targetFrameRate = 60;
    }

    private void Update()
    {
        if (timerOn)
        {
            if (timeLeft < 119 && (timeLeft < 60 || changeBackground == false))
            {
                timeLeft += Time.deltaTime;
                UpdateTimer(timeLeft);
            }
            else if (timeLeft < 119 && timeLeft >= 60 && changeBackground == true)
            {
                background.GetComponent<MeshRenderer>().sharedMaterial = material;

                timeLeft += Time.deltaTime;
                UpdateTimer(timeLeft);

                FindObjectOfType<Parallax>().animationSpeed = 0.20f;
                FindObjectOfType<Spawner>().spawnRate = 5f;

                changeBackground = false;
            }
            else
            {
                GameOver();
                timeLeft = 0;
                timerOn = false;
            }
        }
    }

    public void Play()
    {
        scoreText.enabled = true;
        title.enabled = false;
        player.enabled = true;

        playButton.SetActive(false);
        helpButton.SetActive(false);
        gameOver.SetActive(false);
        panel.SetActive(false);

        score = 0;
        scoreText.text = score.ToString();

        Time.timeScale = 1f;
        timerOn = true;

        SoulFragments[] soulFragments = FindObjectsOfType<SoulFragments>();

        for(int i = 0; i < soulFragments.Length; i++)
        {
            Destroy(soulFragments[i].gameObject);
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
        playButton.SetActive(true);
        helpButton.SetActive(true);
        panel.SetActive(true);

        float min = FindObjectOfType<BTManagerRespirometer>().volArray.Min();
        float max = FindObjectOfType<BTManagerRespirometer>().volArray.Max();
        float average = FindObjectOfType<BTManagerRespirometer>().volArray.Average();

        Debug.Log("min: " + min);
        Debug.Log("max: " + max);
        Debug.Log("average: " + average);

        Pause();
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    void UpdateTimer(float currentTime)
    {
        currentTime += 1;

        float seconds = Mathf.FloorToInt(currentTime % 120);

        timerText.text = seconds.ToString();
    }
}
