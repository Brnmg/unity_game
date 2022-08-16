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
    private float moveHorizontal;
    private float moveVertical;

    // Start is called before the first frame update
    private void Start()
    {
        // Get the player's (gameObject) RigidBody2D values
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        moveSpeed = .05f;
    }

    // Update is called once per frame
    void Update()
    {
        moveHorizontal = joystick.Horizontal;
        moveVertical = joystick.Vertical;
    }

    private void FixedUpdate()
    {
        if (moveHorizontal > 0.1f || moveHorizontal < -0.1f)
        {
            GetComponent<SpriteRenderer>().sprite = shipIdle;
            rb2D.AddForce(new Vector2(moveHorizontal * moveSpeed, 0), ForceMode2D.Impulse);
        }
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
}
