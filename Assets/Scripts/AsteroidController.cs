using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{

    private ScoreManager scoreManager;

    private void Start()
    {
        scoreManager = GameObject.Find("Canvas").GetComponent<ScoreManager>();
    }

    // Collision stands for the object that is colliding with this object. In this case collision = Player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            scoreManager.score -= 1;
            Destroy(gameObject);
            
        }
    }
}
