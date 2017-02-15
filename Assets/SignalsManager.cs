using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalsManager : MonoBehaviour {

	public ScoreSignal scoreSignal;

	void Start () {
		Events.OnEnemyHurt += OnEnemyHurt;
	}
	
	void OnEnemyHurt(Vector3 pos, int qty)
	{
		ScoreSignal ss = Instantiate (scoreSignal);
		ss.Init (World.Instance.heroTransform, pos, qty);
	}
}
