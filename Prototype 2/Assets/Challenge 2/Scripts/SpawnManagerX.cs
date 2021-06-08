using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private readonly float spawnLimitXLeft = -22;
    private readonly float spawnLimitXRight = 7;
    private readonly float spawnPosY = 30;

    private float startDelay = 1.0f;
    private readonly float spawnInterval = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating(nameof(SpawnRandomBall), startDelay, spawnInterval);
        Invoke(nameof(SpawnRandomBall), startDelay);
    }

    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall ()
    {

        // Generate random ball index and random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

        // instantiate ball at random spawn location
        int ballIndex = Random.Range(0, ballPrefabs.Length);
        Instantiate(ballPrefabs[ballIndex], spawnPos, ballPrefabs[0].transform.rotation);

        startDelay = Random.Range(3.0f, 5.0f);
        Invoke(nameof(SpawnRandomBall), startDelay);
    }

}
