using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
	public Text goldDisplayer;
	public Text goldPerClickDisplay;

	public DataContoller dataController;


	
	void Update () {
		goldDisplayer.text = "Gold : " + dataController.GetGold();
		goldPerClickDisplay.text = "GoldPerClick : " + dataController.GetGoldPerClick();

	}
}
