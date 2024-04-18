using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopScript : MonoBehaviour
{
    private Coroutine DelayDeleteCorutine;

    // Start is called before the first frame update
    void Start()
    {
        if (DelayDeleteCorutine == null)
        {
            DelayDeleteCorutine = StartCoroutine(DelayDelete());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DelayDelete()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(this.gameObject);
    }
}
