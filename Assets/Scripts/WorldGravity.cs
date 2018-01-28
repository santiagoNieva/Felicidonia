using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGravity : MonoBehaviour {

	public float gravityForce = 9.8f;

	Rigidbody rb;

	void Awake()
	{
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 direction = new Vector3 (0, 0, 0) - transform.position;
		rb.AddForce (direction * gravityForce);
		
	}
}
