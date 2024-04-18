using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public GameObject popPrefab;
    public Material collectedMaterial;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        //If we collide with the ground
        if (collision.gameObject.CompareTag("Player"))
        {
            //Change to pop particle prefab
            Instantiate(popPrefab, transform.position, Quaternion.identity);
            StartCoroutine(CoinDelete());
        }
    }

    IEnumerator CoinDelete()
    {
        GetComponent<Renderer>().material = collectedMaterial;

        yield return new WaitForSeconds(0.2f);

        Destroy(this.gameObject);
        Debug.Log("Coin Collected");
    }
}
