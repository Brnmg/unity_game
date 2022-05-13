using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text textScore;
    public int score;


    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        textScore.text = "Pontuação: " + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        textScore.text = "Pontuação: " + score.ToString();
    }
}
