using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectableManager : MonoBehaviour
{
    public TextMeshProUGUI collectableDisplay;
    public int numberOfPlumbobs;

    public GameObject plumbobPrefab;

    // Start is called before the first frame update
    void Start()
    {
        UpdateCount();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateCount()
    {
        StartCoroutine(DelayedUpdateCount());
    }

    public IEnumerator DelayedUpdateCount()
    {
        yield return new WaitForEndOfFrame();

        foreach (GameObject collectable in GameObject.FindGameObjectsWithTag("Collectable"))
        {

        }

        numberOfPlumbobs = GameObject.FindGameObjectsWithTag("Collectable").Length;
        collectableDisplay.text = $"Plumbob's left: {numberOfPlumbobs}";
        if (numberOfPlumbobs <= 0)
        {
            AllDone();
        }
    }

    public void AllDone()
    {
        Debug.Log("Doneso");
    }
}
