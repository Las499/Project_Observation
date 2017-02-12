using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour {

    //Hovering up and down setting
    [SerializeField]
    private float HorizontalSpeed = 2f;
    [SerializeField]
    private float VerticalSpeed = 2f;
    [SerializeField]
    private float Amplitude = 10f;
    [SerializeField]
    private float minHeight = .5f;
    [SerializeField]
    private float maxHeight = 1f;
    [SerializeField]
    private float adjustmentSpeed = 15f; //used to adjust the speed on repositioing uneven terrain


    //Hovering right and left setting
    [SerializeField]
    private bool sideHover = true;
    [SerializeField]
    private float sHorizontalSpeed = 2f;
    [SerializeField]
    private float sVerticalSpeed = 2f;
    [SerializeField]
    private float sAmplitude = 10f;

    [SerializeField]
    private float TurnSpeed = 2f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float vInput = Input.GetAxisRaw("Vertical");
        float hInput = Input.GetAxisRaw("Horizontal");

        //Hovering up and down
        Vector3 _movVertical = transform.right * vInput;
        Vector3 _hover = transform.up * Mathf.Sin(Time.realtimeSinceStartup * VerticalSpeed) * Amplitude;

        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            if (hit.distance < minHeight)
            {
                _hover.y += hit.distance * adjustmentSpeed * Time.fixedDeltaTime;
            }
            else if (hit.distance > maxHeight)
            {
                _hover.y -= hit.distance * adjustmentSpeed * Time.fixedDeltaTime;
            }
        }


        Vector3 movement = _movVertical + _hover;

        //allow swaying side
        if (_movVertical == Vector3.zero && sideHover)
        {
            Vector3 _sideSway = transform.forward * Mathf.Cos(Time.realtimeSinceStartup * sVerticalSpeed) * sAmplitude;
            movement += _sideSway;
        }

        rb.MovePosition(rb.position + movement * HorizontalSpeed * Time.fixedDeltaTime);

        //rotate the object
        Vector3 turn = transform.up * hInput;
        rb.angularVelocity = turn * TurnSpeed;

    }
}
