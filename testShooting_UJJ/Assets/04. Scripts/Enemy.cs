using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	private float m_fSpeed = 1.3f;

	void Update()
	{
		float distanceY = Time.deltaTime * m_fSpeed;

		this.gameObject.transform.Translate(0, -distanceY, 0);


       
    }

	void OnBecameInvisible()
	{
		Destroy(this.gameObject);
	}


}
