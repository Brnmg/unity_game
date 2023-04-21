using TMPro;
using UnityEngine;
using System.Linq;


public class GameManager : MonoBehaviour
{
    public PlayerController player;

    public GameObject playButton;
    public GameObject gameOver;
    public GameObject panel;
    public GameObject helpPanel;
    public GameObject helpButton;

    public TMP_Text scoreText;
    public TMP_Text title;
    public TMP_Text timerText;
    public TMP_Text minValue;
    public TMP_Text maxValue;
    public TMP_Text averageValue;

    public Material material;
    public Material originalMaterial;
    public Renderer background;

    private int score;

    public float timeLeft;
    public bool timerOn = false;
    public bool changeBackground = true;

    public void Awake()
    {
        scoreText.enabled = false;
        timerOn = true;
        title.enabled = true;

        gameOver.SetActive(false);
        panel.SetActive(false);
        helpPanel.SetActive(false);

        FindObjectOfType<PlayerController>().OnEnable();

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
                background.GetComponent<MeshRenderer>().material = material;

                timeLeft += Time.deltaTime;
                UpdateTimer(timeLeft);

                FindObjectOfType<Parallax>().animationSpeed = 0.20f;
                FindObjectOfType<Spawner>().spawnRate = 5f;

                changeBackground = false;
            }
            else
            {
                GameOver();
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
        helpPanel.SetActive(false);

        score = 0;
        scoreText.text = score.ToString();

        FindObjectOfType<Parallax>().animationSpeed = 0.13f;
        FindObjectOfType<Spawner>().spawnRate = 7f;

        background.GetComponent<MeshRenderer>().material = originalMaterial;
        changeBackground = true;

        Time.timeScale = 1f;
        timerOn = true;

        SoulFragments[] soulFragments = FindObjectsOfType<SoulFragments>();

        for (int i = 0; i < soulFragments.Length; i++)
        {
            Destroy(soulFragments[i].gameObject);
        }
    }

    public void Help()
    {
        helpPanel.SetActive(true);
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

        timeLeft = -1;
        timerOn = false;

        Pause();

        if(FindObjectOfType<BTManagerRespirometer>().volArray.Count > 0)
        {
            float min = FindObjectOfType<BTManagerRespirometer>().volArray.Min();
            float max = FindObjectOfType<BTManagerRespirometer>().volArray.Max();
            float average = FindObjectOfType<BTManagerRespirometer>().volArray.Average();

            Debug.Log(min);
            Debug.Log(max);
            Debug.Log(average);

            minValue.text = string.Format("{0:0.##} L/s", min);
            maxValue.text = string.Format("{0:0.##} L/s", max);
            averageValue.text = string.Format("{0:0.##} L/s", average);
        }
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
