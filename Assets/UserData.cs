using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserData : MonoBehaviour {

	public int money;

	void Start () {
		Invoke ("Delayed", 0.5f);
		Events.OnMoneyUpdate += OnMoneyUpdate;
	}
	void Delayed()
	{
		money = World.Instance.settings.user.initialMoney;
	}
	void OnMoneyUpdate(int qty)
	{
		money += qty;
		Events.OnMoneyUpdated(money);
	}

}
