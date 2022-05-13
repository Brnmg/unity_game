using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    private float length;
    private float startPos;
    private GameObject cam;
    // The SerializeField property allows the variable to be edited inside the editor without making it public
    [SerializeField] private float parallaxEffect;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera");
        startPos = transform.position.x;
        length = gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        float distance = (cam.transform.position.x * parallaxEffect);
        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);

        if (temp > startPos + length)
        {
            startPos += length;
        }
        else if (temp < startPos - length)
        {
            startPos -= length;
        }
    }
}
