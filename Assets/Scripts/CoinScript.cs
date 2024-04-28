using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public GameObject popPrefab;
    public Material collectedMaterial;
    public TextMeshProUGUI coinsCollectedUI;
    public GameObject eventSystem;
    public UIManager uiManager;
    public int coinsCollected;
    


    // Start is called before the first frame update
    void Start()
    {
        eventSystem = GameObject.Find("EventSystem"); //Sets eventSystem to the EventSystem object.
        //Debug.Log(eventSystem.name);
        coinsCollectedUI = FindObjectOfType<TextMeshProUGUI>(); //Sets coinsCollectedUI to the UI element for collected coins.
        //Debug.Log(coinsCollectedUI.name);
        uiManager = eventSystem.GetComponent<UIManager>(); //Sets uiManager to the UI manager script.
        //Debug.Log(uiManager.name);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) //Checks if the player is colliding with the object.
        {
            //Change to pop particle prefab
            uiManager.coinsCollected += 1; //Increases coinsCollected by 1 in the uiManager script.
            Instantiate(popPrefab, transform.position, Quaternion.identity); //Spawns a pop particle effect.
            StartCoroutine(CoinDelete()); //Begins the CoinDelete function.
        }
    }

    IEnumerator CoinDelete()
    {
        GetComponent<Renderer>().material = collectedMaterial; //Changes the coin's look to the collected version.
        coinsCollectedUI.text = uiManager.coinsCollected.ToString(); //Increases the UI coin counter by 1.
        //Debug.Log(coinsCollected);

        yield return new WaitForSeconds(0.2f); //Waits 0.2 seconds.

        Destroy(this.gameObject); //Removes the coin from the scene.
        //Debug.Log("Coin Collected");
    }
}
