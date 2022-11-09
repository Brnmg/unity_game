using UnityEngine;

public class Parallax : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    public float animationSpeed = 0.13f;
    
    void Start()
    {
       meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        meshRenderer.material.mainTextureOffset += new Vector2(animationSpeed * Time.deltaTime, 0);
    }
}
