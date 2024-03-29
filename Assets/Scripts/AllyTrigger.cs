﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyTrigger : MonoBehaviour
{
    private AudioSource MyAudioSource;
    public AudioClip CollisionSound;

    private void Start()
    {
        MyAudioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            MyAudioSource.PlayOneShot(CollisionSound);
            transform.position = new Vector3(200, 200, 200);
            Destroy(gameObject, CollisionSound.length);
            other.gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
