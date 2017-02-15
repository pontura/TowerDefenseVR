using UnityEngine;
using System.Collections;

public class Hero : MonoBehaviour {

    public Weapon weapon;

	void Start () {
		Events.OnLeftTriggerPress += OnLeftTriggerPress;
		Events.OnLeftTriggerRelease += OnLeftTriggerRelease;
    }
	void OnLeftTriggerPress() {
		Vector3 pos = Vector3.zero;
		weapon.OnTriggerPress(pos);
	}
	void OnLeftTriggerRelease() {
		Vector3 pos = Vector3.zero;
		weapon.OnTriggerRelease(pos);
	}
	public void SetNewRotation(Vector3 rot)
	{
		transform.localEulerAngles = rot;
	}
}
