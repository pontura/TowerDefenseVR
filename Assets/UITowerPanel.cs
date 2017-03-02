using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITowerPanel : MonoBehaviour {

	public int towerPositionID;
	public TextMesh field;
	public UiTower ui;

	void Start(){
		Events.OnMoneyUpdated += OnMoneyUpdated;
		OnMoneyUpdated (Data.Instance.userData.money);
	}
	public void Selected (Tower.types type) {		
		if (Data.Instance.userData.money > World.Instance.settings.prices.defenderBow) {
			Events.OnMoneyUpdate(-World.Instance.settings.prices.defenderBow);
			ui.Selected (type, towerPositionID);
		} else {
			field.text = "No money!";
			Invoke ("OnEnable", 2);
		}
	}
	void OnMoneyUpdated(int money)
	{
		field.text = "$" + money;
	}
}
