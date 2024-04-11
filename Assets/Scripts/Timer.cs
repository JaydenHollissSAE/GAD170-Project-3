using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public int timeLeft = 60;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TimerStart());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator TimerStart()
    {
        yield return new WaitForSeconds(1);
        timeLeft -= 1;
        if (timeLeft < 0)
        {
            StartCoroutine(TimerStart());
        }
    }
}
