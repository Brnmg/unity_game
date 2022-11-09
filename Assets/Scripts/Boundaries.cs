using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{

    private Vector2 screenBounds;
    private float objectHeight;

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1 + objectHeight, screenBounds.y - objectHeight);
        transform.position = viewPos;
    }
}
