using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Closet : ItemBox {
    private bool m_open;
    OpenDoor c_opendoor;

	void Start () {
		
	}
	
	void Update () {
		
	}

    public void Open()
    {

    }

    public override bool CheckEvent()
    {
        return false;
    }
}
