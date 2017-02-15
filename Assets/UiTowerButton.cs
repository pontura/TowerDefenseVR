using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiTowerButton : MonoBehaviour {

	public Material mat_normal;
	public Material mat_over;
	public MeshRenderer meshRenderer;

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
	public void Clicked()
	{
		uiTowerPanel.Selected (type);
	}
	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "InteractiveHand") {
			Clicked ();
			meshRenderer.material = mat_over;
		}
	}
	void OnTriggerExit(Collider col)
	{
		if (col.gameObject.tag == "InteractiveHand") {
			meshRenderer.material = mat_normal;
		}
	}

}
