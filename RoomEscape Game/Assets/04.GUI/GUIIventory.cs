using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIIventory : MonoBehaviour {
    public GUIItemList m_cItemList;
    public GUIPanel m_cPanel;

	void Start () {
    
    }
	
	void Update () {

        

    }


	public void SetIventory(ItemManager.eItem eitem)
	{
		m_cItemList.AddItem(eitem);
	}
    
    public void SetPanel(ItemManager.eItem eitem)
    {
        
        m_cPanel.Set(eitem);
    }


}
