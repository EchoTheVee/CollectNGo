using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int collectablesGotten = 0;
    public CollectableManager cm;
    
    // Start is called before the first frame update
    void Start()
    {
        cm = GameObject.Find("CollectableManager").GetComponent<CollectableManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
