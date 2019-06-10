using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    
    // Use this for initialization
    void Start()
    {
        InvokeRepeating("Move", 1, 1);
    }

    // Update is called once per frame
    public void Move()
    {

        Rigidbody body = GetComponent<Rigidbody>();
        body.AddForce(new Vector3(0, 0, 0));
        body.AddForce(new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)));

    }
}
