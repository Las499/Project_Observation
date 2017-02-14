using UnityEngine;
using System.Collections;

public class IslandHover : MonoBehaviour {

    //Hovering up and down setting
    [SerializeField]
    private float HorizontalSpeed = .5f;
    [SerializeField]
    private float VerticalSpeed = 2f;
    [SerializeField]
    private float Amplitude = .2f;


    void FixedUpdate()
    {
        //Hovering up and down
        Vector3 _hover = transform.up * Mathf.Sin(Time.time * VerticalSpeed) * Amplitude;
        transform.position = transform.position + _hover * HorizontalSpeed * Time.fixedDeltaTime;
    }
}
