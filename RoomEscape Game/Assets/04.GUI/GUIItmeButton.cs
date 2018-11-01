using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIItmeButton : MonoBehaviour {

    public Text Btext;
    public ItemManager.eItem InvenItem;
    
	void Start () {
		
	}
	
	void Update () {
		
	}
	//버튼 Text에 이름넣는 함수
    public void SetText(string text)
    {
        Btext.text = text;
    }

	public void OnClick()
	{
        //버튼이 가지고 있는 아이템목록 중 content부분만 Panel에 있는 Text에 넣는다.
        GameManager.GetInstance().m_cGUIManager.m_listScenes[2].GetComponentInChildren<GUIPanel>().Set(InvenItem);
	}

   
 
}
