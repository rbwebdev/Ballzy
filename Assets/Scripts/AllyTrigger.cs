using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            other.gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
