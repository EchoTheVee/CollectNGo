using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    private ExitController ec;
    // Start is called before the first frame update
    void Start()
    {
        ec = GameObject.Find("Door").GetComponent<ExitController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        ec.NextLevelTP();
    }
}
