using UnityEngine;
using System.Collections;

public class Defender : Character
{
    public override void OnStart()
    {
		settings.energy = World.Instance.settings.defenders.energy;
        settings.force = World.Instance.settings.defenders.force;
        settings.frequency_to_attack = World.Instance.settings.defenders.frequency_to_attack;
        settings.speed_to_run = World.Instance.settings.defenders.speed_to_run;
        settings.speed_to_target = World.Instance.settings.defenders.speed_to_target;
       // gravityApplier.target = World.Instance.ground.transform;
    }
    public override void OnFixedUpdate()
    {
        switch (action)
        {
            case actions.ATTACKING:
                attack.FixedUpdateByManager();
                break;
        }
    }

	public override void OnAreaViewOff(Character character)
	{
		if(attack.target == character)
			Idle ();
	}
    public override void OnAreaViewActive(Character character)
    {
		if (attack.target != null) {
			float distanceToOldTarget = Vector3.Distance(attack.target.transform.position, transform.position);
			float distanceToNewTarget = Vector3.Distance(character.transform.position, transform.position);
			if(Mathf.Abs(distanceToOldTarget) < Mathf.Abs(distanceToNewTarget))
				return;
		}
        attack.Init(character);
        action = actions.ATTACKING;
    }
    public override void OnEnemyKilled()
    {
		Idle ();
    }
	void Idle()
	{
		action = actions.IDLE;
	}
}
