﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
    }
}
