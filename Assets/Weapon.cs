using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

    public Proyectil proyectil;
	public Transform container;

    public virtual void OnTriggerPress(Vector3 to)
    {
    }
	public virtual void OnTriggerRelease(Vector3 to)
	{
	}
	public void Shoot(Vector3 direction, Vector3 startPosition, int force)
	{
		Proyectil newProyectil = Instantiate (proyectil);
		newProyectil.transform.position = startPosition;
		newProyectil.Init (direction, force);
	}
}
