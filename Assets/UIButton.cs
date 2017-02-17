using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiButton : MonoBehaviour {

	public Material mat_normal;
	public Material mat_over;

	public MeshRenderer meshRenderer;

	public void Clicked()
	{
		meshRenderer.material = mat_over;
		Invoke ("Reset", 1);
		OnClicked ();
	}
	public virtual void OnClicked() { }
	void Reset()
	{
		meshRenderer.material = mat_normal;
	}
	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "InteractiveHand") {
			Clicked ();
		}
	}

}
