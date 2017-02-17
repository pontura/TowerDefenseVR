using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiTowerButton : UiButton {

	public Tower.types type;
	public TextMesh field;

	public UITowerPanel uiTowerPanel;

	public int qty;

	void OnEnable()
	{
		int price = 0;
		switch (type) {
		case Tower.types.BOW_ATTACK:
			//price = World.Instance.settings.prices.defenderBow;
			break;
		case Tower.types.SOLDIERS:
			//price = World.Instance.settings.prices.defenderSoldiers;
			break;
		}
		field.text = "$" + price;
	}
	public override void OnClicked()
	{
		uiTowerPanel.Selected (type);
	}

}
