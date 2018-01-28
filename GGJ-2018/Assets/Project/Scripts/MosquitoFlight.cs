using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MosquitoFlight : MonoBehaviour
{
    public bool IsMosquitoInfected;

    public float speed;
    //public Vector3 testCamera;
    public Rigidbody rb;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //testCamera = Camera.main.transform.forward;
        if (Input.GetAxis("Vertical")>0.01)
        {
            
            rb.velocity = GameObject.FindGameObjectWithTag("MainCamera").transform.forward * speed;


        }

    }
}
