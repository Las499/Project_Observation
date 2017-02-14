using UnityEngine;
using System.Collections;

public class SinkFloat2 : MonoBehaviour
{

    public Transform target;
    public float speed = 2f;

    Transform initalPos;

    void Start()
    {
        initalPos = transform;
    }


    void Update()
    {

        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if (target.position == transform.position)
        {
            GetComponent<IslandHover>().enabled = true;
            enabled = false;
        }

    }
}
