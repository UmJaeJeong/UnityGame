using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataContoller : MonoBehaviour {

	private static DataContoller instance;

	public static DataContoller GetInstance()
	{
		if(instance == null)
		{
			instance = FindObjectOfType<DataContoller>();
			if(instance == null)
			{
				GameObject container = new GameObject("DataController");
				instance = container.AddComponent<DataContoller>();
			}
		}
		return instance;
	}

	private int gold = 0;
	private int goldPerClick = 0;

	void Awake()
	{
		gold = PlayerPrefs.GetInt("Gold");
		goldPerClick = PlayerPrefs.GetInt("GoldPerClick", 1);
	}

	public void SetGold(int newGold)
	{
		gold = newGold;
		PlayerPrefs.SetInt("Gold", gold);
	}

	public void AddGold(int newGold)
	{
		gold += newGold;
		SetGold(gold);
	}

	public void AddGoldPerClick(int newGoldPerClick)
	{
		goldPerClick += newGoldPerClick;
		SetGoldPerClick(goldPerClick);
	}

	public void SubGold(int newGold)
	{
		gold -= newGold;
		SetGold(gold);
	}

	public int GetGold()
	{
		return gold;
	}

	public int GetGoldPerClick()
	{
		return goldPerClick;
	}

	public void SetGoldPerClick(int newGoldPerClick)
	{
		goldPerClick = newGoldPerClick;
		PlayerPrefs.SetInt("GoldPerClick", goldPerClick);
	}

	public void LoadUpgradeButton(UpgradeButton upgradeButton)
	{
		string key = upgradeButton.upgradeName;
		upgradeButton.level = PlayerPrefs.GetInt(key + "_level", 1);
		upgradeButton.goldByUpgrade = PlayerPrefs.GetInt(key + "_goldByUprade", upgradeButton.startGoldByUpgrade);
		upgradeButton.currentCost = PlayerPrefs.GetInt(key + "_cost", upgradeButton.startCurrentCost);

	}

	public void SaveUpgradeButton(UpgradeButton upgradeButton)
	{
		string key = upgradeButton.upgradeName;
		PlayerPrefs.SetInt(key + "_level", upgradeButton.level);
		PlayerPrefs.SetInt(key + "_goldByUpgrade", upgradeButton.goldByUpgrade);
		PlayerPrefs.SetInt(key + "_cost", upgradeButton.currentCost);
	}

	public void LoadItemButton(ItemButton itemButton)
	{
		string key = itemButton.itemName;
		itemButton.level = PlayerPrefs.GetInt(key + "_level");
		itemButton.currentCost = PlayerPrefs.GetInt(key + "_cost", itemButton.startCurrentCost);
		itemButton.goldPerSec = PlayerPrefs.GetInt(key + "_goldPerSec");
		if (PlayerPrefs.GetInt(key + "_isPurchsed") == 1)
		{
			itemButton.isPurchased = true;
		}
		else
		{
			itemButton.isPurchased = false;
		}
	}
	public void SaveItemButton(ItemButton itemButton)
	{
		string key = itemButton.itemName;
		PlayerPrefs.SetInt(key + "_level", itemButton.level);
		PlayerPrefs.SetInt(key + "_cost", itemButton.currentCost);
		PlayerPrefs.SetInt(key + "_goldPerSec", itemButton.goldPerSec);
		if (itemButton.isPurchased == true)
		{
			PlayerPrefs.SetInt(key + "_isPurchsed", 1);

		}
		else
		{
			PlayerPrefs.SetInt(key + "_isPurchsed", 0);
		}
	}

}
