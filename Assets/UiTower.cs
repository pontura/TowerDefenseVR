using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiTower : MonoBehaviour {

	[HideInInspector]
	public Tower activeTower;

	void Start()
	{
		Events.OnTeleport += OnTeleport;
	}
	void OnTeleport(Tower tower)
	{
		this.activeTower = tower;

		if(tower.ui_container != null)
			transform.position = tower.ui_container.transform.position;
	}
	public void Selected(Tower.types towerType, int towerPositionID)
	{
		activeTower.ChangeType (towerType, towerPositionID);
	}

}
