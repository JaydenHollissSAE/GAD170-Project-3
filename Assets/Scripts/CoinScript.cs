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
        eventSystem = GameObject.Find("EventSystem");
        //Debug.Log(eventSystem.name);
        coinsCollectedUI = FindObjectOfType<TextMeshProUGUI>();
        //Debug.Log(coinsCollectedUI.name);
        uiManager = eventSystem.GetComponent<UIManager>();
        //Debug.Log(uiManager.name);
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
            uiManager.coinsCollected += 1;
            Instantiate(popPrefab, transform.position, Quaternion.identity);
            StartCoroutine(CoinDelete());
        }
    }

    IEnumerator CoinDelete()
    {
        GetComponent<Renderer>().material = collectedMaterial;
        coinsCollectedUI.text = uiManager.coinsCollected.ToString();
        //Debug.Log(coinsCollected);

        yield return new WaitForSeconds(0.2f);

        Destroy(this.gameObject);
        //Debug.Log("Coin Collected");
    }
}
