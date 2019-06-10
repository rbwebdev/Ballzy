using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyMove : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("Move", 2, 0.5f);
    }

    // Update is called once per frame
    public void Move()
    {

        Rigidbody body = GetComponent<Rigidbody>();
        body.AddForce(new Vector3(0, 0, 0));
        body.AddForce(new Vector3(Random.Range(-30, 30), 0, Random.Range(-30, 30)));

    }
}
