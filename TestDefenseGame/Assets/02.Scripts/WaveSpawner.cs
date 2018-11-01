using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WaveSpawner : MonoBehaviour {
	public Transform enemyPrefabs;
	public Transform spawnPoint;

	public float timeBetweenWaves = 5.0f;
	private float countdown = 2.0f;

	public int waveIndex = 1;
	public int MaxwaveIndex = 6;

	//public Text waveCountdownText;
	
	void Update () {
		if (countdown <= 0.0f){
			StartCoroutine(SpawnWave());
			countdown = timeBetweenWaves;
		}
		countdown -= Time.deltaTime;
		//waveCountdownText = Mathf.Round(countdown).ToString();
	}

	IEnumerator SpawnWave()
	{
		Debug.Log("Wave Incomming!!");
		waveIndex++;
		if(waveIndex > MaxwaveIndex)
		{
			waveIndex = MaxwaveIndex;
		}
		for (int i = 0; i < waveIndex; i++)
		{
			spawnEnemy();
			yield return new WaitForSeconds(0.5f);
		}
	}

	void spawnEnemy()
	{
		Instantiate(enemyPrefabs, spawnPoint.position, spawnPoint.rotation);
	}
}
