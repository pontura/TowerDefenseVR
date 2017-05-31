using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {

    [HideInInspector] public Character character;
    [HideInInspector] public Character target;

    private float _speed = 1;


    void Start()
    {
        character = GetComponent<Character>();
		_speed = World.Instance.settings.defenders.speed_to_target;
    }
    public void Init(Character target)
    {
        this.target = target;
        Loop();
    }
    public void Stop()
    {
        this.target = null;
    }
    public virtual void FixedUpdateByManager()
    {
		if (character == null)
			return;
        if (target == null)
        {
            character.OnEnemyKilled();
            return;
        }
        float step = _speed / 10 * Time.deltaTime;
		
		Vector3 direction = transform.position - target.transform.position;
		Quaternion toRotation = Quaternion.LookRotation(direction);
		toRotation.x = 0;
		toRotation.z = 0;
		transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, 2.5f * Time.deltaTime);

    }
    public virtual void Loop()
    {
        CancelInvoke();

		if (target != null && character != null)
       		target.Attacked(character.settings.force);
		if(character != null)
        	Invoke("Loop", character.settings.frequency_to_attack);
    }
}
