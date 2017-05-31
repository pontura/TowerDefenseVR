using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class Bomb : VRTK_InteractableObject {
	float spinSpeed = 0f;
	Transform rotator;

	public void Explote()
	{
		Events.OnAddExplotion (transform.position);
		Destroy (gameObject);
	}
	public override void StartUsing(GameObject usingObject)
	{
		base.StartUsing(usingObject);
		spinSpeed = 360f;
	}

	public override void StopUsing(GameObject usingObject)
	{
		base.StopUsing(usingObject);
		spinSpeed = 0f;
	}

	protected override void Start()
	{
		base.Start();
		rotator = transform.Find("Capsule");
	}

	protected override void Update()
	{
		if(rotator != null)
			rotator.transform.Rotate(new Vector3(spinSpeed * Time.deltaTime, 0f, 0f));
	}
}