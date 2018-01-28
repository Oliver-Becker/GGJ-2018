using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public bool IsMosquitoInfected;

	public float mv_speed;
	private Rigidbody rigid;

	// Use this for initialization
	void Start () {
		rigid = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0) || Input.GetAxis("Vertical")>0.01)
			rigid.velocity = GameObject.FindGameObjectWithTag("MainCamera").transform.forward * mv_speed;
	}
}
