using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombsManager : MonoBehaviour {

	public Bomb bomb;
	public GameObject container;

	void Start () {		
		
		foreach (Bomb go in container.GetComponentsInChildren<Bomb>())
			AddSceneObject (go.transform.position);

		Destroy (container);

	}
	void AddSceneObject(Vector3 pos)
	{
		Bomb newBomb = Instantiate (bomb);
		newBomb.transform.SetParent (World.Instance.world.transform);
		bomb.transform.position = pos;
	}
}
