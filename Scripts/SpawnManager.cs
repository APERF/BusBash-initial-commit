using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] randomPrefabs;

    private Vector3 spawnPosition;

    private float startDelay = 1f;
    
    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        SpawnStart();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        spawnPosition = new Vector3(Random.Range(7, -7), 1, 15);
    }

    public void SpawnStart()
    {
        float spawnRate = Random.Range(1f, 2f);
        InvokeRepeating("SpawnObstacle", startDelay, spawnRate);
    }

    void SpawnObstacle()
    {
        int randomPrefabsIndex;
        randomPrefabsIndex = Random.Range(0, randomPrefabs.Length);

        if (playerController.gameOver == false)
        {
            Instantiate(randomPrefabs[randomPrefabsIndex], spawnPosition, transform.rotation);
        }
    }
}
