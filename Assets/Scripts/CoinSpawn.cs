using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawn : MonoBehaviour
{
    public GameObject CoinPrefab;
    private Vector3 randomPosition;
    private float spawnTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        {
            for (int i = 0; i < 30; i++) //Performs a loop of code 30 times.
            {
                spawnTime += Random.Range(0.2f, 3f); //Gives a random spawn time from 0.2 to 3 for every coin, accounting for each other's time.
                //Debug.Log(spawnTime);
                StartCoroutine(SpawnWait()); //Starts the SpawnWait function.
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnWait()
    {
        yield return new WaitForSeconds(spawnTime); //Waits for the time decided by spawnTime.
        //Debug.Log("Spawning New Coin"); 
        randomPosition = new Vector3(Random.Range(-30, 30), Random.Range(20, 35), Random.Range(-30, 30)); //Gets a bew random position for the coin to spawn on the map.
        Instantiate(CoinPrefab, randomPosition, Quaternion.identity); //Spawns a new coin based on randomPosition's location.
    }

}
