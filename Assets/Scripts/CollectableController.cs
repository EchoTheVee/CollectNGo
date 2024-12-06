using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableController : MonoBehaviour
{
    public GameManager gm;
    

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gm.collectablesGotten += 1;
            GameObject.Find("CollectableManager").GetComponent<CollectableManager>().UpdateCount();
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }


    }
}
