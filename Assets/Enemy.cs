using UnityEngine;
using System.Collections;

public class Enemy : Character
{
    private PathfinderNodesManager pathNodes;
    public GameObject asset;
	public float speed;
	public Animator anim;

    public override void OnStart()
    {
        moveToTArget.Init(this);
        settings.force = World.Instance.settings.enemies.force;
        settings.frequency_to_attack = World.Instance.settings.enemies.frequency_to_attack;
        settings.speed_to_run = World.Instance.settings.enemies.speed_to_run;
        settings.speed_to_target = World.Instance.settings.enemies.speed_to_target;

        pathNodes = GetComponent<PathfinderNodesManager>();
		speed = World.Instance.settings.enemies.speed_to_run;
		anim.Play ("walk");
    }
    public void SetMoveToTarget(Transform target)
    {
        moveToTArget.target = target;
    }
	public override void OnDie() {
		
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
		anim.Play ("idle");
    }
    public override void OnEnemyKilled()
    {
        action = actions.MOVEING_TO_TARGET;
		anim.Play ("walk");
    }
}
