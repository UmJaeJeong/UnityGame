using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    string m_strName;
    string m_strComent;
    string m_strImage;

    public Item()
    {

    }

    public void Set(string name, string coment, string Image)
    {
        m_strName = name;
        m_strComent = coment;
        m_strImage = Image;
    }

    public string Name
    {
        get { return m_strName; }
       // set { m_strName = value; }
    }

    public string Content
    {
        get { return m_strComent; }
        //set { m_strComent = value; }
    }

    public string Image
    {
        get { return m_strImage; }
        //set { m_strImage = value; }
    }
}

public class ItemManager : MonoBehaviour {
    List<Item> m_listItems = new List<Item>();
    public enum eItem
    {
        NONE = -1, KEY01, KEY02, KEY03, KEY04, KEY, Tool_Kit
    };

    public bool Init()
    {
        m_listItems.Add(new Item());
        m_listItems[0].Set("Key_Piece1", "열쇠조각1", "이미지");
        m_listItems.Add(new Item());
        m_listItems[1].Set("Key_Piece2", "열쇠조각2", "이미지");
        m_listItems.Add(new Item());
        m_listItems[2].Set("Key_Piece3", "열쇠조각3", "이미지");
        m_listItems.Add(new Item());
        m_listItems[3].Set("Key_Piece4", "열쇠조각4", "이미지");
        m_listItems.Add(new Item());
        m_listItems[4].Set("Key", "열쇠", "이미지");
        m_listItems.Add(new Item());
        m_listItems[5].Set("Tool_Kit", "툴키트", "이미지");
        return false;
    }

    private void Start()
    {
        Init();
    }

    public bool LoadItemInfo()
    {
        return false;
    }

    public Item GetItem(int item)
    {
        return m_listItems[item];
    }

    public Item GetItem(eItem e_item)
    {
        return m_listItems[(int)e_item];
    }



}
