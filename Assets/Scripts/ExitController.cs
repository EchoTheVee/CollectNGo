using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitController : MonoBehaviour
{
    public MeshRenderer mr;
    public Material locked;
    public Material unlocked;
    public GameManager gm;
    public CollectableManager cm;

    // Start is called before the first frame update
    void Start()
    {
        cm = GameObject.Find("CollectableManager").GetComponent<CollectableManager>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        mr.material = locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (cm.numberOfPlumbobs <= 0)
        {
            mr.material = unlocked;
        }
        else
        {
            mr.material = locked;
        }
    }
}
