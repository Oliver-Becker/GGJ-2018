using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class CharacterMove : MonoBehaviour {

	public GameObject[] waypoint;
	private int count;
	private int rand_num;
	private Vector3 destination;

	// Use this for initialization
	void Start () {
		waypoint = GameObject.FindGameObjectsWithTag ("WayPoint");
		count = waypoint.Length;
		rand_num = Random.Range (0, count);
		destination = waypoint [rand_num].transform.position;
		GetComponent<NavMeshAgent>().SetDestination(destination);
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance(gameObject.transform.position, destination) < 2){
			rand_num = Random.Range (0, count);
			destination = waypoint [rand_num].transform.position;
			GetComponent<NavMeshAgent>().SetDestination(destination);
		}
	}

}
