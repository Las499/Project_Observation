using UnityEngine;
using System.Collections;

public class Spin : MonoBehaviour {

    [SerializeField]
    float speed = 1.5f;

    void FixedUpdate()
    {
        float vInput = Input.GetAxisRaw("Vertical");
        float hInput = Input.GetAxisRaw("Horizontal");

        Vector3 vRot = Vector3.forward * vInput;
        transform.Rotate((vRot) * speed * Time.fixedDeltaTime);
    }
}
