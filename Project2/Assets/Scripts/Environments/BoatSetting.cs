using UnityEngine;
using System.Collections;

public class BoatSetting : MonoBehaviour {

    public Transform positions;

    public GameObject player;

    public Transform playerMoveTo;

    public GameObject[] Walls;

    public float speed;


    void FixedUpdate()
    {

        transform.position = Vector3.MoveTowards(transform.position, positions.position, speed * Time.fixedDeltaTime);

        if(transform.position == positions.position)
        {
            player.transform.position = Vector3.MoveTowards(player.transform.position, playerMoveTo.position, speed * Time.deltaTime);

            if(player.transform.position == playerMoveTo.position)
            {
                foreach(GameObject wall in Walls)
                {
                    wall.GetComponent<Collider>().enabled = true;
                }
                player.transform.parent = null;
                player.GetComponent<Movement>().enabled = true;
                enabled = false;
            }
        }


        
    }

}
