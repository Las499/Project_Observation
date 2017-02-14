using UnityEngine;
using System.Collections;
//this class needs to be fix.
public class IslandTrigger : MonoBehaviour {

    public GameObject[] Walls;

    public SinkFloat island;

    public GameObject boat;
    public GameObject stand;

    public Transform moveTo;

    public float speed = 1f;

    private bool enable;
    private GameObject player;

    void Start()
    {
        enable = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            foreach (GameObject wall in Walls)
            {
                Collider collider = wall.GetComponent<Collider>();
                collider.enabled = false;
            }

            if (island != null)
                island.enabled = true;

            player = other.gameObject;
            player.GetComponent<Movement>().enabled = false;
            player.GetComponent<Rigidbody>().MoveRotation(player.GetComponent<Rigidbody>().rotation);
            enable = true;
        }
    }

    void FixedUpdate()
    {
        if (enable == true)
        {
            
            player.transform.position = Vector3.MoveTowards(player.transform.position, moveTo.position, speed * Time.deltaTime);

            if(player.transform.position == moveTo.position)
            {
                player.transform.parent = stand.transform;
                boat.GetComponent<BoatSetting>().enabled = true;
                enabled = false;
            }
        }
    }
}
