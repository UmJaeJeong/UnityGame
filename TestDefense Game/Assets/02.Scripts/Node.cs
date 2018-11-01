using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {

	public Color hoverColor;
	public Vector3 positionOffset = new Vector3(0,3,0);

	public GameObject turret;

	private Renderer rend;
	private Color startColor;

	void Start ()
	{
		rend = GetComponent<Renderer>();
		startColor = rend.material.color;
	}

	private void OnMouseDown()
	{
		if(turret != null)
		{
			Debug.Log("Can not build here!!");
			return;
		}

		GameObject turretToBuild = BuildManager.instance.GetTurretBuild();
		turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
	}

	private void OnMouseEnter()
	{
		rend.material.color = Color.green;
	}

	private void OnMouseExit()
	{
		rend.material.color = startColor;
	}

	void Update () {
		
	}
}
