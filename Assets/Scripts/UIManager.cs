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
        endScreen.SetActive(false); //Hides the ending screen.
        StartCoroutine(GameTimerFunc()); //Starts the main code loop.
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(coinsCollected);
        if (gameEnd) //Checks if the gameEnd flag is met.
        {
            if (Input.GetKeyDown(KeyCode.Delete)) //Checks if the Delete key is being pressed.
            {
                //Debug.Log("Run");
                endScreen.SetActive(false); //Hides the ending screen.
                Instantiate(coinSpawnerPrefab, new Vector3(0, 0, 0), Quaternion.identity); //Spawns a new instance of the Coin Spawner.
                coinSpawner = GameObject.FindGameObjectWithTag("Spawner"); //Attaches the new coin spawner to the coinSpawner object.
                timeRemaining = 65; //Sets timeRemaining to 65.
                coinsCollected = 0; //Sets coinsCollected to 0.
                StartCoroutine(GameTimerFunc()); //Starts the main code loop.
            } 
        }
    }

    public void EndGameFunc()
    {
        Destroy(coinSpawner); //Removes the coin spawner from the scene.
        endScreen.SetActive(true); //Shows the ending screen.
        //Instantiate(endPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        gameEnd = true; //Sets the gameEnd flag to true.
        scoreList.Add(coinsCollected); //Adds the score to scoreList
        //Debug.Log(coinsCollected);
        for (int i = 0; i < scoreList.Count; ++i) //Performs a loop for every item in scoreList.
        {
            if (highScoreBuffer < scoreList[i]) //Checks if highScoreBuffer is smaller than the selected item in scoreList.
            {
                highScoreBuffer = scoreList[i]; //Sets highScoreBuffer to the selected item in scoreList.
            }
        }

        //Debug.Log(GameObject.FindGameObjectWithTag("ScoreTrackerTag").name);
        //highScore = GameObject.FindGameObjectWithTag("ScoreTrackerTag").GetComponent<TMPro.TextMeshProUGUI>();
        //Debug.Log(highScore.name);
        //Debug.Log(highScore.text);
        highScore.text = "High Score:" +
            " " + highScoreBuffer.ToString(); //Sets the highScore text to the respective high score.
    }

    IEnumerator GameTimerFunc()
    {

        yield return new WaitForSeconds(1.0f); //Waits 1 second.

        timeRemaining -= 1; //Removes 1 from timeRemaining.
        //Debug.Log(timeRemaining);
        if (timeRemaining < 6) //Checks if timeRemaining is below 6.
        {
            gameTimer.text = "<color=#FF2D00>" + timeRemaining.ToString() + "s</color>"; //Sets time remaining on Ui with red colour.

        }
        else
        {
            gameTimer.text = timeRemaining.ToString() + "s"; //Sets time remaining on UI.

        }

        if (timeRemaining > 0) //Checks if timeRemaining is above 0.
        {

            StartCoroutine(GameTimerFunc()); //Repeats the main function.
        }
        else
        {
            EndGameFunc(); //Runs the end of game function.
        }

    }

}
