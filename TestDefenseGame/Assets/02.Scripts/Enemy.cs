using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	public float speed = 10.0f;
	private Transform target;
	private int wavepointIndes = 0;
	void Start () {
		target = Wavepoint.points[0];
	}
	
	void Update () {
		Vector3 dir = target.position - transform.position;
		transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
		transform.LookAt(target);
		if (Vector3.Distance(transform.position, target.position) <=0.4f)
		{
			GetNextWavePoint();
		}
		
	}

	void GetNextWavePoint()
	{
		if(wavepointIndes >= Wavepoint.points.Length - 1)
		{
			Destroy(gameObject);
			return;
		}
		wavepointIndes++;
		target = Wavepoint.points[wavepointIndes];
	}
}
