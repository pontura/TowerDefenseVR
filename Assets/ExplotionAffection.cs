using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplotionAffection : MonoBehaviour {

	private Character character;

	void Start () {
		character = GetComponent<Character> ();
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Explotion") {
			character.Attacked (100);
		}
	}
}
