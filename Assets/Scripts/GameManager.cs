using TMPro;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public PlayerController player; 
    public TMP_Text scoreText;
    public GameObject playButton;
    public GameObject gameOver;
    public GameObject panel;
    private int score;

    public void Awake()
    {
        gameOver.SetActive(false);
        panel.SetActive(false);
        Pause();
        Application.targetFrameRate = 60;
    }

    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();

        playButton.SetActive(false);
        gameOver.SetActive(false);
        panel.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;

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
        panel.SetActive(true);

        Pause();
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
