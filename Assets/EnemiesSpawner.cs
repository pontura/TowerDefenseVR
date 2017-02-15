using UnityEngine;
using System.Collections;

public class EnemiesSpawner : MonoBehaviour {

    public Enemy enemy;
    public PathFinderNode firstNode;

    private int id=0;
    private float time_to_spawn;
	private int wait_to_respawn;
    private int total;

    void Start () {
		Invoke ("Delayed", 1f);
    }
	void Delayed () {
		this.total = World.Instance.settings.spawn_enemies.total;
		this.time_to_spawn = World.Instance.settings.spawn_enemies.time_to_spawn;
		this.wait_to_respawn = World.Instance.settings.spawn_enemies.wait_to_respawn;
		LoopSpawn();
	}
	void LoopSpawn()
    {
        id++;
		CreateEnemy();
		if (id < total)
			Invoke ("LoopSpawn", time_to_spawn);
		else
			Respawn ();        
    }
	void Respawn()
	{
		Invoke("LoopSpawn", wait_to_respawn);
		id = 0;
	}
    void CreateEnemy()
    {
        Enemy newEnemy = Instantiate(enemy);
        Vector3 pos = transform.position;
		newEnemy.transform.SetParent(World.Instance.world.transform);
		newEnemy.transform.position = pos;
        newEnemy.SetMoveToTarget(firstNode.transform);
    }
}
