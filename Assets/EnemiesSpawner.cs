using UnityEngine;
using System.Collections;

public class EnemiesSpawner : MonoBehaviour {

    public Enemy enemy1;
	public Enemy enemy2;
	public Enemy enemy3;

	public Transform startingPath;
    public PathFinderNode firstNode;

    private int enemiesSpawnedID=0;
    private float time_to_spawn;
	private int wait_to_respawn;
    private int total;

	private Waves waves;
	private Wave actualWave;

    void Start () {
		waves = GetComponent<Waves> ();
		Invoke ("CreateNewWave", 1f);
    }
	void CreateNewWave () {
		actualWave = waves.GetWave ();
		this.total = actualWave.enemies.Count;
		this.time_to_spawn = 1.2f;
		this.wait_to_respawn = actualWave.delay;
		LoopSpawn();
	}
	void LoopSpawn()
    {		
		Enemy.types enemyType = actualWave.enemies [enemiesSpawnedID];		
		enemiesSpawnedID++;
		
		CreateEnemy(enemyType);
		if (enemiesSpawnedID < total)
			Invoke ("LoopSpawn", time_to_spawn);
		else
			Respawn ();        
    }
	void Respawn()
	{
		waves.SetNewWave ();
		Invoke("CreateNewWave", wait_to_respawn);
		enemiesSpawnedID = 0;
	}
	void CreateEnemy(Enemy.types type)
    {
		Enemy newEnemy;
		switch (type) {
		case Enemy.types.SMALL:
			newEnemy = Instantiate(enemy1);
			break;
		case Enemy.types.MEDIUM:
			newEnemy = Instantiate(enemy2);
			break;
		default:
			newEnemy = Instantiate(enemy3);
			break;
		}
		Vector3 pos = startingPath.position;
		newEnemy.transform.SetParent(World.Instance.world.transform);
		newEnemy.transform.position = pos;
        newEnemy.SetMoveToTarget(firstNode.transform);
		newEnemy.Init (type);
    }
}
