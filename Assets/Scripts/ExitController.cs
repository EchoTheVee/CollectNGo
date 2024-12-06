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
    public GameObject levelOneSpawn;
    public GameObject player;
    public GameObject plumbob1;
    public GameObject plumbob2;
    public GameObject plumbob3;
    public GameObject plumbob4;
    public GameObject plumbob5;
    public Clock clock;

    // Start is called before the first frame update
    void Start()
    {
        clock = GameObject.Find("Clock").GetComponent<Clock>();
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

    private void OnCollisionEnter(Collision collision)
    {
        if (mr.material = unlocked)
        {

            NextLevelTP();

        }        
    }

    public void NextLevelTP()
    {
        Debug.Log("NextLevel");
        player.transform.position = levelOneSpawn.transform.position;
        plumbob1.SetActive(true);
        plumbob2.SetActive(true);
        plumbob3.SetActive(true);
        plumbob4.SetActive(true);
        plumbob5.SetActive(true);
        cm.UpdateCount();
        clock.startTime = 120;
        clock.time = 120;
    }
}
