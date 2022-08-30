using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Sprite shipIdle, shipDown, shipUp;
    private Rigidbody2D rb2D;
    public Joystick joystick;

    // Player's physics 
    private float moveSpeed;
    private float moveVertical;

    private void Start()
    {
        // Get the player's (gameObject) RigidBody2D values
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        moveSpeed = .05f;
    }

    void Update()
    {
    }

    private void FixedUpdate()
    {
        if (moveVertical > 0.1f)
        {
            GetComponent<SpriteRenderer>().sprite = shipUp;
            rb2D.AddForce(new Vector2(0, moveVertical * moveSpeed), ForceMode2D.Impulse);
        }
        if (moveVertical < -0.1f)
        {
            GetComponent<SpriteRenderer>().sprite = shipDown;
            rb2D.AddForce(new Vector2(0, moveVertical * moveSpeed), ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Scoring")
        {
            FindObjectOfType<GameManager>().IncreaseScore();
        }        
    }
}
