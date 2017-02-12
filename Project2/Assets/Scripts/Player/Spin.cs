using UnityEngine;
using System.Collections;

public class Spin : MonoBehaviour {

    [SerializeField]
    float speed = 2f;

    void FixedUpdate()
    {
        float vInput = Input.GetAxisRaw("Vertical");
        float hInput = Input.GetAxisRaw("Horizontal");

        Vector3 vRot = Vector3.forward * vInput;
        Vector3 hRot = Vector3.right * hInput;
        transform.Rotate((vRot+hRot) * speed * Time.fixedDeltaTime);
    }
}
