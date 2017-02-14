using UnityEngine;
using System.Collections;

public class platformtrigger : MonoBehaviour {

    public GameObject[] platforms;

    public GameObject[] walls;

    public int countdown = 2;
    private int initalcountdown;
    private int countup = 0;

    private bool enable = false;

    void Start()
    {
        enable = false;
        initalcountdown = countdown;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            foreach(GameObject wall in walls)
            {
                wall.GetComponent<Collider>().enabled = false;
            }

            enable = true;

        }
    }

    // Update is called once per frame
    void Update () {

        if (enable)
        {
            foreach(GameObject plat in platforms)
            {
                plat.GetComponent<SinkFloat2>().enabled = true;
            }

            enabled = false;
        }
	}
}
