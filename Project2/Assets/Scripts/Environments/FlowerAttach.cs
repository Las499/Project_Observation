using UnityEngine;
using System.Collections;

public class FlowerAttach : MonoBehaviour {

    void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Player")
        {

        }

    }

    void Attach(Collision obj)
    {

    }
}
