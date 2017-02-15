using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class LeftHand : MonoBehaviour
{
	SteamVR_TrackedObject trackedObj;

	void Awake()
	{
		trackedObj = GetComponent<SteamVR_TrackedObject>();	
	}
	void FixedUpdate()
	{		
		var device = SteamVR_Controller.Input((int)trackedObj.index);
		if (device.GetTouchDown (SteamVR_Controller.ButtonMask.Trigger)) {
			Events.OnLeftTriggerPress ();
		} else if (device.GetTouchUp (SteamVR_Controller.ButtonMask.Trigger)) {
			Events.OnLeftTriggerRelease ();
		}
	}
}