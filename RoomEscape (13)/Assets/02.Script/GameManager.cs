using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public Player m_cPlayer;
    public ItemManager m_cItemManager;
    public GUIManager m_cGUIManager;
	//ItemBox 스크립트를 가진 Object를 리스트로 구현 
    public List<ItemBox> m_listItemBox = new List<ItemBox>();
    public enum eItemBox {BED, DESK, CLOSET, BOOK, TOOL_KIT, EXIT };

    //싱글톤
    static GameManager m_cInstance = null;

    public static GameManager GetInstance()
    {
        return m_cInstance; //스타트 했을때 인스턴스는 차 있을것이다.
        //원래라면 생성자를 private해야 된다 
        //private를 해도 별소용이 없이 MonoBehaviour을 상속받기 때문에 public이 된다.
    }

    private void Awake()
    {
        m_cInstance = this;
    }

    void Start () {
		
	}
	
	void Update () {
		
	}

    public void Event(eItemBox itembox)
    {
		int idx = (int)itembox;
        switch (itembox)
        {
            case eItemBox.BED:
                if (m_listItemBox[(int)itembox].CheckEvent())
                {
                    m_cPlayer.SetInventory(m_listItemBox[idx].eItem);
                    m_cGUIManager.m_listScenes[2].GetComponent<GUIIventory>().m_cItemList.AddItem(m_listItemBox[idx].eItem);
                    m_listItemBox[idx].eItem = ItemManager.eItem.NONE;
                }

                break;

            case eItemBox.DESK:
                if (m_listItemBox[idx].CheckEvent())
                {
                    m_cPlayer.SetInventory(m_listItemBox[idx].eItem);
                    m_cGUIManager.m_listScenes[2].GetComponent<GUIIventory>().m_cItemList.AddItem(m_listItemBox[idx].eItem);
                    m_listItemBox[idx].eItem = ItemManager.eItem.NONE;
                }
                break;

            case eItemBox.CLOSET:
                if (m_listItemBox[idx].CheckEvent())
                {
                    m_cPlayer.SetInventory(m_listItemBox[idx].eItem);
                    m_cGUIManager.m_listScenes[2].GetComponent<GUIIventory>().m_cItemList.AddItem(m_listItemBox[idx].eItem);  
                    m_listItemBox[idx].eItem = ItemManager.eItem.NONE;

                }
                break;

            case eItemBox.BOOK:
                if (m_listItemBox[idx].CheckEvent())
                {
                    m_cPlayer.SetInventory(m_listItemBox[idx].eItem);
                    m_cGUIManager.m_listScenes[2].GetComponent<GUIIventory>().SetIventory(m_listItemBox[idx].eItem);
                    m_listItemBox[idx].eItem = ItemManager.eItem.NONE;
                }
                break;

            case eItemBox.TOOL_KIT:
                if (m_listItemBox[idx].CheckEvent())
                {
                    if (m_cPlayer.CheckInventory(3)==true)
                    {
                        m_cPlayer.DeletInventory();
                        m_cGUIManager.m_listScenes[2].GetComponent<GUIIventory>().m_cItemList.ReleaseItem();
                        m_cPlayer.SetInventory(ItemManager.eItem.KEY);
                        m_cGUIManager.m_listScenes[2].GetComponent<GUIIventory>().m_cItemList.AddItem(ItemManager.eItem.KEY);
                    }
                }
                break;

            case eItemBox.EXIT:
                if (m_listItemBox[idx].CheckEvent())
                {
					if(m_cPlayer.m_InventoryList[0].Name == "Key")
					{
						m_cGUIManager.SetStatus(GUIManager.eSceneStatus.THEEND);
						m_cGUIManager.UpdataStatus();
					}
                }
                break;
        }
    }
}
