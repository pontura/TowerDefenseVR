using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplotionsManager : MonoBehaviour {

	public Explotion explotion;
	public Transform container;

	void Start () {
		Events.OnAddExplotion += OnAddExplotion;
	}
	void OnDestroy () {
		Events.OnAddExplotion -= OnAddExplotion;
	}
	void OnAddExplotion(Vector3 pos)
	{
		Explotion new_explotion = Instantiate (explotion);
		new_explotion.Init (pos);
	}
}
