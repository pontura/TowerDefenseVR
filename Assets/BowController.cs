using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowController : MonoBehaviour {
	
	public Transform bowPoint1;
	public Transform bowPoint2;
	GameObject rope1;
	GameObject rope2;
	public GameObject ropeStatic;
	bool isWorking;
	public Material ropeMaterial;

	void Awake()
	{
		rope1 = new GameObject();
		rope2 = new GameObject();
	}
	public void ResetRope()
	{
		isWorking = false;
		rope1.SetActive (false);
		rope2.SetActive (false);
		ropeStatic.SetActive (true);
	}

	public void UpdateArrowPosition(Vector3 arrowPosition)
	{
		if (!isWorking) {
			ropeStatic.SetActive (false);
			rope1.SetActive (true);
			rope2.SetActive (true);
		}
		isWorking = true;
		DrawLine (rope1, bowPoint1.transform.position, arrowPosition, Color.white);
		DrawLine (rope2, arrowPosition, bowPoint2.transform.position, Color.white);
	}
	void DrawLine(GameObject rope, Vector3 start, Vector3 end, Color color)
	{		
		rope.transform.position = start;
		rope.AddComponent<LineRenderer>();
		LineRenderer lr = rope.GetComponent<LineRenderer>();
		lr.material = ropeMaterial;
		//lr.SetColors(color, color);
		lr.SetWidth(0.002f, 0.002f);
		lr.SetPosition(0, start);
		lr.SetPosition(1, end);
	}
}
