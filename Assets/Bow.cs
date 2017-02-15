using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : Weapon {

	public GameObject bow;
	public GameObject arrow;
	private float timeToReload = 1;

	public Vector2 arrowPositions;

	public states state;
	public enum states
	{
		IDLE,
		ACTIVE
	}

	public override void OnTriggerPress(Vector3 to)
	{
		arrow.SetActive (true);
		state = states.ACTIVE;
	}
	private float min_Distance = 0.10f;
	private float max_Distance = 0.56f;

	private float max_force = 150;
	private float min_force = 2;
	public float lastTimeShooted = 0;
	public override void OnTriggerRelease(Vector3 to)
	{
		if (lastTimeShooted != 0 && (lastTimeShooted + timeToReload) > Time.time)
			return;
		lastTimeShooted = Time.time;
		arrow.SetActive (false);
		state = states.IDLE;
		float force = 100;
		float distance = Vector3.Distance(arrow.transform.position, bow.transform.position);
		if(distance<min_Distance) distance = min_Distance; 
		if(distance>max_Distance) distance = max_Distance; 
		force = ((distance - min_Distance) / (max_Distance - min_Distance)) * (max_force - min_force) + min_force;
		Shoot (arrow.transform.forward, arrow.transform.parent.position, (int)force);
	}
	void Update()
	{
		if (state == states.IDLE)
			return;
		arrow.transform.LookAt (bow.transform);
	}

}
