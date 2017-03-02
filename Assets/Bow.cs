using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : Weapon {

	public BowController bow;
	public ThrowableWeapon arrow;

	private float timeToReload = 1;

	public Vector2 arrowPositions;

	public states state;
	public enum states
	{
		IDLE,
		WAITING_TO_ACTIVE,
		ACTIVE
	}

	private float min_Distance = 0.10f;
	private float Distance_to_active= 0.3f;
	private float max_Distance = 0.56f;

	private float max_force = 150;
	private float min_force = 2;
	public float lastTimeShooted = 0;

	void Start()
	{
		bow.gameObject.SetActive (false);
		Idle ();
	}
	public override void OnTriggerPress(Vector3 to)
	{
		arrow.gameObject.SetActive(true);
		arrow.SetOff ();
		state = states.WAITING_TO_ACTIVE;
		HandEvents.Grab (HandController.types.LEFT);
	}
	public override void OnTriggerRelease(Vector3 to)
	{		
		if (state != states.ACTIVE) {
			Idle ();
			return;
		}
		//if (lastTimeShooted != 0 && (lastTimeShooted + timeToReload) > Time.time)
			//return;		
		float force = 100;
		float distance = Vector3.Distance(arrow.transform.position, bow.transform.position);
		if(distance<min_Distance) distance = min_Distance; 
		if(distance>max_Distance) distance = max_Distance; 
		force = ((distance - min_Distance) / (max_Distance - min_Distance)) * (max_force - min_force) + min_force;
		Shoot (arrow.transform.forward, arrow.transform.parent.position, (int)force);
		Idle ();
	}
	void Update()
	{
		if (state == states.IDLE)
			return;
		else if (state == states.WAITING_TO_ACTIVE) {
			float distance = Vector3.Distance(arrow.transform.position, bow.transform.position);
			if(distance<Distance_to_active && arrow.transform.localPosition.z < bow.transform.localPosition.z)
				state = states.ACTIVE;
		} else {		
			arrow.SetOn();	
			arrow.transform.LookAt (bow.transform);
			bow.UpdateArrowPosition (arrow.transform.position);

			if (arrow.transform.localPosition.z > bow.transform.localPosition.z)
				Idle ();
		}
	}
	void Idle()
	{
		HandEvents.Idle (HandController.types.LEFT);
		lastTimeShooted = Time.time;

		state = states.IDLE;
		bow.ResetRope ();
		arrow.gameObject.SetActive(false);
	}

}
