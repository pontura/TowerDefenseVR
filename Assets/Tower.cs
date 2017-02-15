using System.Collections;
using UnityEngine;

public class Tower : MonoBehaviour {

	public Transform ui_container;
	public DefenderBow defenderBow;
	//public DefenderZone defenderZone;

	public Transform container1;
	public Transform container2;
	public Transform container3;
	public Transform container4;

	public types type;
	public enum types
	{
		SIMPLE,
		BOW_ATTACK,
		SOLDIERS
	}
	public float _height;

	void OnEnable()
	{
		//if(container1 != null)
		//Invoke ("Delayed", 1);
	}
	void Delayed()
	{
		//ChangeType (types.BOW_ATTACK, 1);
	}
	public void ChangeType(types newType, int id)
	{
		
		Transform container = GetContainer (id);
		Utils.RemoveAllChildsIn (container);

		Defender defender = null;
		switch (newType) {
		case types.BOW_ATTACK:
			defender = defenderBow;
			break;
		case types.SOLDIERS:
			return;
			//defender = defenderZone;
			break;
		}
		Defender newDefender = Instantiate (defender);
		newDefender.transform.SetParent (container);
		newDefender.transform.localEulerAngles = Vector3.zero;
		newDefender.transform.localPosition = Vector3.zero;
	}
	public void AddUI()
	{

	}
	Transform GetContainer(int id)
	{
		switch (id) {
		case 1:
			return container1;
		case 2:
			return container2;
		case 3:
			return container3;
		default:
			return container4;
		}
	}

}
