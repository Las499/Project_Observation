using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour {

    [SerializeField]
    private float maxVelocity = 1f;
    [SerializeField]
    private float JumpForce = 10f;
    [SerializeField]
    private float minAngularDrag = 0f;
    [SerializeField]
    private float maxAngularDrag = 50f;

    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;

    private bool isFalling = false;

    private Rigidbody rb;
	
	void Start () {

        rb = GetComponent<Rigidbody>();
	}
	//cleanup
    void FixedUpdate()
    {
        float vInput = Input.GetAxis("Vertical");
        float hInput = Input.GetAxis("Horizontal");

        Vector3 _movVertical = transform.right * vInput;

        rb.MovePosition(rb.position + _movVertical * maxVelocity * Time.deltaTime);
        rb.angularVelocity = new Vector3(0f, hInput * 2f, 0f);

        
        if(Input.GetButton("Jump") && isFalling == false)
        {
            Vector3 _JumpForce = Vector3.up * JumpForce * Time.fixedDeltaTime;
            rb.velocity= _JumpForce;

            isFalling = true;
            Debug.Log("Hello "+ _JumpForce);
        }
    }

    void OnCollisionStay()
    {
        isFalling = false;
    }

    public void Move(Vector3 velocity)
    {
        this.velocity = velocity;
    }

    public void Turn(Vector3 rotation)
    {
        this.rotation = rotation;
    }

    private void PerformMove()
    {
        if (velocity != Vector3.zero)
        {
            rb.angularDrag = minAngularDrag;
            rb.AddForce(velocity);

            if (rb.velocity.magnitude > maxVelocity)
            {
                Vector3 newVelocity = rb.velocity.normalized;
                newVelocity *= maxVelocity;
                rb.velocity = newVelocity;
            }
        }
        else
            rb.angularDrag = maxVelocity;
    }

    private void PerformRotation()
    {
        transform.Rotate(rotation);
    }
}
