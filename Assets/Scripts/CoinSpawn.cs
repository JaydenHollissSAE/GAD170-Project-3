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
            for (int i = 0; i < 30; i++)
            {
                spawnTime += Random.Range(0.2f, 3f);
                //Debug.Log(spawnTime);



                //Create random transform position

                StartCoroutine(SpawnWait());


            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnWait()
    {
        yield return new WaitForSeconds(spawnTime);
        Debug.Log("Spawning New Coin");
        randomPosition = new Vector3(Random.Range(-30, 30), Random.Range(20, 35), Random.Range(-30, 30));

        Instantiate(CoinPrefab, randomPosition, Quaternion.identity);
    }

}
