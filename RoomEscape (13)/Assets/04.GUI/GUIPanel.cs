using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GUIPanel : MonoBehaviour {
    public Image Pimage;
    public Text Ptext;
    public Sprite[] Item_Object = new Sprite[2];

	private Item cItem;

	void Start () {
		
	}
	
	void Update () {
		
	}
	
	//아이템 Content와 Image 넣기
    public void Set(ItemManager.eItem item)
    {
		cItem = GameManager.GetInstance().m_cItemManager.GetItem(item);
		Ptext.text = cItem.Content;
        if (item != ItemManager.eItem.KEY)
        {
            Pimage.overrideSprite = Item_Object[0];
        }
        else Pimage.overrideSprite = Item_Object[1];



    }

    private void OnDisable()
    {
        Ptext.text = null;
        Pimage.overrideSprite = null;
    }


}
