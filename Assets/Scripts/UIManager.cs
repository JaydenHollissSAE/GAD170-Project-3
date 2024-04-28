using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public List<int> scoreList = new List<int>();
    public int coinsCollected = 0;
    public TextMeshProUGUI gameTimer;
    public int timeRemaining;
    public GameObject endPrefab;
    public TextMeshProUGUI highScore;
    public GameObject endScreen;
    public bool gameEnd;
    public int highScoreBuffer = 0;
    public GameObject coinSpawner;
    public GameObject coinSpawnerPrefab;


    // Start is called before the first frame update
    void Start()
    {
        endScreen.SetActive(false);
        StartCoroutine(GameTimerFunc());
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(coinsCollected);
        if (gameEnd)
        {
            if (Input.GetKeyDown(KeyCode.Delete)) 
            {
                //Debug.Log("Run");
                endScreen.SetActive(false);
                Instantiate(coinSpawnerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                coinSpawner = GameObject.FindGameObjectWithTag("Spawner");
                timeRemaining = 65;
                coinsCollected = 0;
                StartCoroutine(GameTimerFunc());
            } 
        }
    }

    public void EndGameFunc()
    {
        Destroy(coinSpawner);
        endScreen.SetActive(true);
        //Instantiate(endPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        gameEnd = true;
        scoreList.Add(coinsCollected);
        Debug.Log(coinsCollected);
        for (int i = 0; i < scoreList.Count; ++i)
        {
            if (highScoreBuffer < scoreList[i])
            {
                highScoreBuffer = scoreList[i];
            }
        }

        //Debug.Log(GameObject.FindGameObjectWithTag("ScoreTrackerTag").name);
        //highScore = GameObject.FindGameObjectWithTag("ScoreTrackerTag").GetComponent<TMPro.TextMeshProUGUI>();
        //Debug.Log(highScore.name);
        //Debug.Log(highScore.text);
        highScore.text = "High Score:" +
            " " + highScoreBuffer.ToString();
    }

    IEnumerator GameTimerFunc()
    {

        yield return new WaitForSeconds(1.0f);

        timeRemaining -= 1;
        //Debug.Log(timeRemaining);
        if (timeRemaining < 6)
        {
            gameTimer.text = "<color=#FF2D00>" + timeRemaining.ToString() + "s</color>";

        }
        else
        {
            gameTimer.text = timeRemaining.ToString() + "s";

        }

        if (timeRemaining > 0) 
        {

            StartCoroutine(GameTimerFunc());
        }
        else
        {
            EndGameFunc();
        }

    }

}
