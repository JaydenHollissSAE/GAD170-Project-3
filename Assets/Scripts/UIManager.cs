using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public int coinsCollected = 0;
    public TextMeshProUGUI gameTimer;
    public int timeRemaining;


    // Start is called before the first frame update
    void Start()
    {
       StartCoroutine(gameTimerFunc());
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(coinsCollected);
    }
    IEnumerator gameTimerFunc()
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

            StartCoroutine(gameTimerFunc());
        }
        else
        {
            St
        }

    }

}
