using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class CharacterMove : MonoBehaviour {

	public GameObject[] waypoint;
	//public GameObject CubeFriend;
	//public GameObject CubeFriend2;
	Vector3 vec1 = new Vector3(20f, 0f, 0f);
	Vector3 vec2 = new Vector3(-23f, 0f, -25f);

	//dimensao do campo: (32, 0, 28) x (-34, 0, -38)

	// Use this for initialization
	void Start () {

		//GetComponent<NavMeshAgent>().SetDestination(CubeFriend.transform.position);
		GetComponent<NavMeshAgent>().SetDestination(vec1);

	}
	
	// Update is called once per frame
	void Update () {
		//if (Vector3.Distance(gameObject.transform.position, CubeFriend.transform.position) < 2){
		if (Vector3.Distance(gameObject.transform.position, vec1) < 2){
			//GetComponent<NavMeshAgent>().SetDestination(CubeFriend2.transform.position);
			GetComponent<NavMeshAgent>().SetDestination(vec2);
		}
	}

}
