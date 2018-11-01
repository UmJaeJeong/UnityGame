using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIItemList : MonoBehaviour {
	//동적할당한 Button들을 넣는 List
    List<GameObject> m_listItem = new List<GameObject>();
	//버튼 동적할당할 GmaeObject
    public GameObject m_ItemButtonPrefab;
	//scrollview의 content
    public GameObject m_Context;

	void Start () {
	}
	
	void Update () {
		
	}
    
	//동적할당으로 아이템을 지닌 버튼을 생성하는 함수
    public void AddItem(ItemManager.eItem item)
    {
		//m_listItem.Add(Instantiate(m_ItemButtonPrefab));
		//m_listItem[(int)item].transform.parent = m_Context.transform;
		//m_listItem[(int)item].GetComponent<GUIItmeButton>().SetText(GameManager.GetInstance().m_cItemManager.GetItem(item).Name);
        
		GameObject objItemButton = Instantiate(m_ItemButtonPrefab);
		objItemButton.transform.parent = m_Context.transform;
		objItemButton.GetComponent<GUIItmeButton>().SetText(GameManager.GetInstance().m_cItemManager.GetItem(item).Name);
        objItemButton.GetComponent<GUIItmeButton>().InvenItem = item;
		m_listItem.Add(objItemButton);
        
	}
    
	
    public bool DeleteItem(ItemManager.eItem item)
    {
        return false;
    }

	//
    public void ReleaseItem()
    {
        for(int i =m_listItem.Count - 1; i >= 0; i--)
        {
            Destroy(m_listItem[i]);
        }
        m_listItem.Clear();
    }
        
    

	//
    public void SetContextSize()
    {

    }
}
