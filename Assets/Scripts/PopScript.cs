using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopScript : MonoBehaviour
{
    private Coroutine DelayDeleteCorutine;

    // Start is called before the first frame update
    void Start()
    {
        if (DelayDeleteCorutine == null) //Checks if DelayDeleteCoroutine exists.
        {
            DelayDeleteCorutine = StartCoroutine(DelayDelete()); //Runs the DelayDelete function.
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DelayDelete()
    {
        yield return new WaitForSeconds(1.5f); //Waits 1 and a half seconds.
        Destroy(this.gameObject); //Removes the pop effect from the scene.
    }
}
