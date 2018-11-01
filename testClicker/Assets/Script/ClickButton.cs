using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickButton : MonoBehaviour {
	//public int gold = 0;
	//public int goldPerClick = 1;
	//public Text Gold;
	//public Text PerClick;
	//public Text PerSec;
	//int time = 1;

	public DataContoller dataController;

	public void OnClick()
	{
		//gold = gold + goldPerClick;
		//goldPerClick++;
		//Gold.text = "Gold : " + gold;
		//PerClick.text = "GoldPerClick : " + goldPerClick;
		//PerSec.text =""+time * Time.deltaTime;

		int goldPerClick = dataController.GetGoldPerClick();
		dataController.AddGold(goldPerClick);
	}

}
