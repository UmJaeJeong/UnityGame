using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour {

	public Text upgradeDisplayer;
	public string upgradeName;
	[HideInInspector]
	public int goldByUpgrade;
	public int startGoldByUpgrade = 1;
	[HideInInspector]
	public int currentCost = 1;
	public int startCurrentCost;
	[HideInInspector]
	public int level = 1;
	public float upgradePow = 1.07f;
	public float costPow = 3.14f;
	void Start()
	{
		//currentCost = startCurrentCost;
		//level = 1;
		//goldByUpgrade = startGoldByUpgrade;
		DataContoller.GetInstance().LoadUpgradeButton(this);

		UpdateUI();
	}
	public void PurchaseUpgrade()
	{
		if (DataContoller.GetInstance().GetGold() >= currentCost)
		{
			DataContoller.GetInstance().SubGold(currentCost);
			level++;
			DataContoller.GetInstance().AddGoldPerClick(goldByUpgrade);
			UpdateUpgrade();
			UpdateUI();
			DataContoller.GetInstance().SaveUpgradeButton(this);
		}
	}
	public void UpdateUpgrade()
	{
		goldByUpgrade = startGoldByUpgrade * (int)Mathf.Pow(upgradePow, level);
		currentCost = startCurrentCost * (int)Mathf.Pow(costPow, level);
	}
	public void UpdateUI()
	{
		upgradeDisplayer.text = upgradeName + "\nCost: " + currentCost + "\nLevel: " + level + "\nNext new GoldPerClick: " + goldByUpgrade;
    }

}
