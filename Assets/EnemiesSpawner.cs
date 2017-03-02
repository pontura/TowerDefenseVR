using UnityEngine;
using System.Collections;

public class EnemiesSpawner : MonoBehaviour {

    public Enemy enemy1;
	public Enemy enemy2;
	public Enemy enemy3;

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
		int enemyID = 0;
		int rand = Random.Range (0, 100);

		if (rand < 33)
			enemyID = 1;
		else if (rand < 66)
			enemyID = 2;
		else
			enemyID = 3;
		
		CreateEnemy(enemyID);
		if (id < total)
			Invoke ("LoopSpawn", time_to_spawn);
		else
			Respawn ();        
    }
	void Respawn()
	{
		total++;
		Invoke("LoopSpawn", wait_to_respawn);
		id = 0;
	}
	void CreateEnemy(int enemyID)
    {
		Enemy newEnemy;
		switch (enemyID) {
		case 1:
			newEnemy = Instantiate(enemy1);
			break;
		case 2:
			newEnemy = Instantiate(enemy2);
			break;
		default:
			newEnemy = Instantiate(enemy3);
			break;
		}
        Vector3 pos = transform.position;
		newEnemy.transform.SetParent(World.Instance.world.transform);
		newEnemy.transform.position = pos;
        newEnemy.SetMoveToTarget(firstNode.transform);
		newEnemy.Init (enemyID);
    }
}
