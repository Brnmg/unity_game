using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Sprite shipIdle, shipDown, shipUp;
    private Rigidbody2D rb2D;

    // Player's physics 
    public float strength = .1f;

    private void Start()
    {
        // Get the player's (gameObject) RigidBody2D values
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {

    }

    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            GetComponent<SpriteRenderer>().sprite = shipUp;
            rb2D.AddForce(new Vector2(0, strength), ForceMode2D.Impulse);
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = shipDown;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Scoring")
        {
            FindObjectOfType<GameManager>().IncreaseScore();
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Limiter") 
        {
            rb2D.velocity = Vector3.zero;
            FindObjectOfType<GameManager>().GameOver();
        }
    }
}
