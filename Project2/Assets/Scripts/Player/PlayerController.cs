using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Movement))]
public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float speed = 2f;
    [SerializeField]
    private float turnSensitivity = 2f;

    private Movement mov;

	void Start () {
        mov = GetComponent<Movement>();
	}
	
	// Update is called once per frame
	void Update () {
        float _hInput = Input.GetAxisRaw("Horizontal");
        float _vInput = Input.GetAxisRaw("Vertical");

        Vector3 _velocity = (_vInput * transform.forward).normalized * speed;
        mov.Move(_velocity);

        Vector3 _Rot = new Vector3(0, _hInput, 0) * turnSensitivity;
        mov.Turn(_Rot);
	}
}
