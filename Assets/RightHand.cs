using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightHand : MonoBehaviour {

	public GameObject bow;

	void Start () {
		HandEvents.Grab (HandController.types.RIGHT);

		HandEvents.Grab += Grab;
		HandEvents.Pointer += Pointer;
	}
	void Pointer(HandController.types type)
	{
		if (type == HandController.types.RIGHT) {
			bow.SetActive (false);
		}
	}
	void Grab(HandController.types type)
	{
		if (type == HandController.types.LEFT) {
			bow.SetActive (true);
			HandEvents.Grab (HandController.types.RIGHT);
		}
	}
}
