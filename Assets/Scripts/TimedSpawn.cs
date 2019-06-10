using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedSpawn : MonoBehaviour {

    public GameObject spawnee;
    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;
    public int maxCount;
    public float range;
    private int countSpawned = 0;

    // Use this for initialization
    void Start () {
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
	}

    public void SpawnObject()
    {
        if (maxCount >= 0 && maxCount == countSpawned)
        {
            stopSpawning = true;
        }
        if (stopSpawning)
        {
            CancelInvoke("SpawnObject");
        } else
        {
            var position = new Vector3(Random.Range(-range, range), 10, Random.Range(-range, range));
            Instantiate(spawnee, position, transform.rotation);
            countSpawned = countSpawned + 1;
        }
    }
}
