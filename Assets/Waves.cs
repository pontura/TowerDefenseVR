using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves : MonoBehaviour {

	public List<Wave> waves;
	public int id;

	public void AddWave(List<Enemy.types> enemies, int delay)
	{
		Wave w = new Wave ();
		w.enemies = enemies;
		w.delay = delay;
		waves.Add (w);
	}
	public Wave GetWave()
	{
		return waves [id];
	}
	public void SetNewWave()
	{
		if (id >= waves.Count-1)
			id = 0;
		id++;
	}

}
