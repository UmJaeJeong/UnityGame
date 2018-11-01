using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour {
    public bool enableSpawn = true;
    public GameObject Enemy;


    void SpawnEnemy()
    {
        float randomX = Random.Range(-0.5f, 0.5f);
        if (enableSpawn)
        {
            GameObject enemy = (GameObject)Instantiate(Enemy, new Vector3(randomX, 1.1f, 0f), Quaternion.identity);
        }
    }
	void Start () {
        InvokeRepeating("SpawnEnemy", 3, 1);
	}
	
	void Update () {
		
	}
}
