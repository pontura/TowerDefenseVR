using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class TeleportingCustom : MonoBehaviour {


	[Tooltip("A string that specifies an object Tag or the name of a Script attached to an object and notifies the teleporter that the destination is to be ignored so the user cannot teleport to that location. It also ensure the pointer colour is set to the miss colour.")]
	public string ignoreTargetWithTagOrClass;
	[Tooltip("A specified VRTK_TagOrScriptPolicyList to use to determine whether destination targets will be acted upon by the Teleporter. If a list is provided then the 'Ignore Target With Tag Or Class' parameter will be ignored.")]
	public VRTK_TagOrScriptPolicyList targetTagOrScriptListPolicy;

	void Start () {
		var leftHand = VRTK_DeviceFinder.GetControllerLeftHand();
		var rightHand = VRTK_DeviceFinder.GetControllerRightHand();
		InitDestinationSetListener(leftHand, true);
		InitDestinationSetListener(rightHand, true);
		foreach (var destinationMarker in VRTK_ObjectCache.registeredDestinationMarkers)
		{
			if (destinationMarker.gameObject != leftHand && destinationMarker.gameObject != rightHand)
			{
				InitDestinationSetListener(destinationMarker.gameObject, true);
			}
		}
	}
	public void InitDestinationSetListener(GameObject markerMaker, bool register)
	{
		if (markerMaker)
		{
			foreach (var worldMarker in markerMaker.GetComponents<VRTK_DestinationMarker>())
			{
				if (register)
				{
					worldMarker.DestinationMarkerSet += new DestinationMarkerEventHandler(DoTeleport);
				}
				else
				{
					worldMarker.DestinationMarkerSet -= new DestinationMarkerEventHandler(DoTeleport);
				}
			}
		}
	}

	void DoTeleport (object sender, DestinationMarkerEventArgs e) {
		
		//if (ValidLocation (e.target, e.destinationPosition) && e.enableTeleport)
			//return;
		
		Tower tower = e.target.gameObject.GetComponent<Tower> ();
		if (tower != null) {
			Vector3 newPos = tower.transform.position;
			newPos.y = tower._height;
			transform.localPosition = newPos;
			Events.OnTeleport (tower);
			return;
		}

		UiButton uiButton = e.target.gameObject.GetComponent<UiButton> ();
		if (uiButton != null) {
			uiButton.Clicked ();
			return;
		}

	}
	protected virtual bool ValidLocation(Transform target, Vector3 destinationPosition)
	{
		if (Utilities.TagOrScriptCheck (target.gameObject, targetTagOrScriptListPolicy, ignoreTargetWithTagOrClass))
			return true;
		return false;
	}

}
