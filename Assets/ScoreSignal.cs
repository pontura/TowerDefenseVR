using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSignal : MonoBehaviour {

	public TextMesh field;

	public void Init(Transform hero, Vector3 pos, int qty)
	{		
		transform.position = pos;
		field.text = "$" + qty;
		Invoke ("Destroy", 2);
		transform.LookAt (hero);
	}
	void Destroy()
	{
		Destroy (gameObject);
	}
}
