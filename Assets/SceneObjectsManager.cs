using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneObjectsManager : MonoBehaviour {

	public Transform container;
	public Tower tower;
	public GameObject towersContainer;

	void Start () {
		Init ();
	}

	void Init () {
		foreach (Tower go in towersContainer.GetComponentsInChildren<Tower>()) {
			Tower newTower = Instantiate (tower);
			newTower.transform.SetParent (container);
			newTower.transform.localPosition = go.transform.localPosition;
		}
		Destroy (towersContainer);
	}
}
