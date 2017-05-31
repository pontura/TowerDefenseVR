using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explotion : MonoBehaviour {
	
	public GameObject asset;

	float speed = 15;
	float _scale = 1;
	private float MAX_SCALE = 14;

	void Start()
	{
	}
	public void Init(Vector3 pos) {
		transform.position = pos;
	}
	void Update()
	{
		_scale += (Time.deltaTime * speed);
		asset.transform.localScale = new Vector3(_scale, _scale, _scale);
		if (_scale > MAX_SCALE)
			Destroy (gameObject);

	}
}
