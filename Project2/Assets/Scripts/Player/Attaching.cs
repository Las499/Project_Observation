using UnityEngine;
using System.Collections;

public class Attaching : MonoBehaviour {

    [SerializeField]
    private GameObject attachedTo;

    void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Flower")
        {
            collision.transform.parent = attachedTo.transform;
            collision.gameObject.GetComponent<SphereCollider>().enabled = false;
        }
        else if(collision.transform.tag == "Hazard")
        {
            Transform[] childs = attachedTo.GetComponentsInChildren<Transform>();
            if(childs.Length != 1)
                Destroy(childs[Random.Range(0, childs.Length - 1)].gameObject);
        }
    }
}
