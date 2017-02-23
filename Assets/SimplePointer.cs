using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class SimplePointer : VRTK_SimplePointer {
	
	bool isOn;

	protected override void Update()
	{
		base.Update();
		if (pointer.gameObject.activeSelf) {
			if (!isOn)
				ChangeState (true);
			isOn = true;
		} else {
			if (isOn)
				ChangeState (false);
			isOn = false;
		}
	}
	void ChangeState(bool _isOn)
	{
		print ("ChangeState " + _isOn);

		if (_isOn)
			HandEvents.Pointer (HandController.types.RIGHT);
		else
			HandEvents.Idle (HandController.types.RIGHT);
	}

}
