using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public bool IsMosquitoInfected;
	public Vector3 pos;
	public Toggle toggle;

	public float mv_speed;
	private Rigidbody rigid;

	// Use this for initialization
	void Start () {
		//toggle = GameObject.FindGameObjectWithTag ("Toggle").GetComponent <Toggle> ();
		pos = transform.position;
		rigid = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0) || Input.GetAxis("Vertical")>0.01)
			rigid.velocity = GameObject.FindGameObjectWithTag("MainCamera").transform.forward * mv_speed;
	}

	public void reset_pos() {
		transform.position = pos;
		IsMosquitoInfected = false;
//		toggle.isOn = IsMosquitoInfected;
		rigid.velocity = new Vector3 (0, 0, 0);

	}

	void OnCollisionEnter() {
		reset_pos ();
	}
}
