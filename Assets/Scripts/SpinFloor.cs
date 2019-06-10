using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinFloor : MonoBehaviour {

    public float speed;
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.down, speed * Time.deltaTime);
	}
}
