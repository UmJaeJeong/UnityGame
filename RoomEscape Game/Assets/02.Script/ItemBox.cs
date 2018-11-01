using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour {
	//각 객체가 가지고 있는 eitem의 값 (enum) 
	public ItemManager.eItem eItem;
    public GameObject Key;

	void Start () {
		
	}
	
	void Update () {
		
	}

    public virtual bool CheckEvent()
    {
		//e_ItemBox = eItem;
        if (eItem != ItemManager.eItem.NONE)
        {

			
			Destroy(Key);
            return true;
        }
        else return false;
            
    }
}
