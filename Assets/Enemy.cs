using UnityEngine;
using System.Collections;

public class Enemy : Character
{
    private PathfinderNodesManager pathNodes;
    public GameObject asset;
	public float speed;
	public Animation anim;

	public types type;
	public enum types
	{
		SMALL,
		MEDIUM,
		BIG
	}

	public void Init(types _type)
	{
		this.type = _type;
		moveToTArget.Init (this);
	}
	public override void OnStart()
	{
		stats.SetEnergy(World.Instance.settings.GetEnemyByType(type).energy);
		settings.force = World.Instance.settings.GetEnemyByType(type).force;
		settings.frequency_to_attack = World.Instance.settings.GetEnemyByType(type).frequency_to_attack;
		settings.speed_to_run = World.Instance.settings.GetEnemyByType(type).speed_to_run;
		settings.speed_to_target = World.Instance.settings.GetEnemyByType(type).speed_to_target;
		speed = settings.speed_to_run;

        pathNodes = GetComponent<PathfinderNodesManager>();

		anim.Play ("walk");
    }
    public void SetMoveToTarget(Transform target)
    {
        moveToTArget.target = target;
    }
	public override void OnDie() {
		anim.Play ("die");
		Invoke ("RemoveObject", 2);
	}
	void RemoveObject()
	{
		Destroy(gameObject);
	}
    public void OnReachPathNode(PathFinderNode oldNode)
    {
        PathFinderNode newNode = pathNodes.GetNewPath(oldNode);
        if (newNode != null)
            SetMoveToTarget(newNode.transform);
        else
        {
            Dead();
        }
    }
    public override void OnFixedUpdate()
    {
		float realSpeed = speed;
        switch(action)
        {
            case actions.MOVEING_TO_TARGET:                
                break;
			case actions.ATTACKING:
				realSpeed /= 2;
                attack.FixedUpdateByManager();
                break;
        }      
		moveToTArget.FixedUpdateByManager(realSpeed);
    }
    public override void OnAreaViewActive(Character character)
    {
        if (action == actions.ATTACKING) return;
        attack.Init(character);
        action = actions.ATTACKING;
		//anim.Play ("idle");
    }
    public override void OnEnemyKilled()
    {
        action = actions.MOVEING_TO_TARGET;
		//anim.Play ("walk");
    }
}
