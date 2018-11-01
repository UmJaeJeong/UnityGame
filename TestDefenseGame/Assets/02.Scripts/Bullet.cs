using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	private Transform target;
	public float speed = 70.0f;
	public GameObject impacetEffect;

	public void Seek(Transform _target)
	{
		target = _target;
	}

	void Start () {
		
	}
	
	void Update () {
		if(target == null)
		{
			Destroy(gameObject);
			return;
		}
		Vector3 dir = target.position - transform.position;
		float distanceThisFrame = speed * Time.deltaTime;

		if(dir.magnitude <= distanceThisFrame)
		{
			HitTarget();
			return;
		}
		transform.Translate(dir.normalized * distanceThisFrame, Space.World);
		transform.LookAt(target);
	}

	void HitTarget()
	{
		GameObject effectIns = (GameObject)Instantiate(impacetEffect, transform.position, transform.rotation);
		Destroy(effectIns, 0.15f);

		Destroy(target.gameObject);
		Destroy(gameObject);
	}
}
