using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameramove : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
		if(Input.mousePosition.x > Screen.width - 1)
		{
			this.gameObject.transform.Translate(new Vector3(1,0,0));
		}

		if (Input.mousePosition.x < 1)
		{
			this.gameObject.transform.Translate(new Vector3(-1, 0, 0));

		}

		if (Input.mousePosition.y > Screen.height - 1)
		{
			this.gameObject.transform.Translate(new Vector3(-1,0, 0),Space.World);

		}

		if (Input.mousePosition.y < 1)
		{
			this.gameObject.transform.Translate(new Vector3(1, 0, 0),Space.World);
		
		}

	}
}
