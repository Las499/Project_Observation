using UnityEngine;
using System.Collections;

public class IslandTrigger : MonoBehaviour {

    public GameObject[] Walls;

    public SinkFloat island;

    void OnTriggerEnter(Collider other)
    {
        foreach (GameObject wall in Walls)
        {
            Collider collider = wall.GetComponent<Collider>();
            collider.enabled = false;
        }

        island.enabled = true;
    }
}
