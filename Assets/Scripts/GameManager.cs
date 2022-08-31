using TMPro;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public PlayerController player; 
    public TMP_Text scoreText;
    public GameObject playButton;
    public GameObject gameOver;
    private int score;

    public void Awake()
    {
        Pause();
        Application.targetFrameRate = 60;
    }

    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();

        playButton.SetActive(false);
        gameOver.SetActive(false);

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

        Pause();
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
