using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITeleportPoint : MonoBehaviour {

	public GameObject asset;
	public Transform lookAtTarget;

	void Start () {
		Events.OnTeleportAvailable += OnTeleportAvailable;
		Events.OnTeleportDisable += OnTeleportDisable;
		Events.OnTeleport += OnTeleport;

		OnTeleportDisable ();
	}

	void OnTeleport(Tower tower)
	{
		OnTeleportDisable ();
	}
	void OnTeleportAvailable (Vector3 point) {
		asset.SetActive(true);
		transform.position = point;
		transform.LookAt (lookAtTarget);
	}
	void OnTeleportDisable () {
		transform.position = new Vector3 (0, -1000, 0);
		asset.SetActive(false);
	}
}
