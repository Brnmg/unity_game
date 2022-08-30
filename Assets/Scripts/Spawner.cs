using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public float spawnRate = 1f;
    public float minHeight = -1f;
    public float maxHeight = 1f;


    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), 3, spawnRate);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        GameObject soulFragments = Instantiate(prefab, transform.position, Quaternion.identity);
        soulFragments.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
    }
}
