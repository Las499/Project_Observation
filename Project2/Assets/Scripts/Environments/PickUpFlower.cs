using UnityEngine;
using System.Collections;

public class PickUpFlower : MonoBehaviour {

	public GameObject explosionPrefab;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter(Collision collision){
		GameObject explosionObject = Instantiate (explosionPrefab, collision.transform.position, Quaternion.identity) as GameObject;
		Destroy(gameObject);
	}
}
