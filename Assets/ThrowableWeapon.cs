using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableWeapon : MonoBehaviour {

	bool isOn;
	public MeshRenderer assetToColorize;
	public Color colorNotActive;
	public Color colorActive;

	public void SetOn() {
		if (isOn)
			return;
		isOn = true;
		assetToColorize.material.color = colorActive;
	}
	public void SetOff() {
		if (!isOn)
			return;
		isOn = false;
		assetToColorize.material.color = colorNotActive;
	}
}
