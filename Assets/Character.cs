using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

    [HideInInspector]    public CharacterStats stats;
    [HideInInspector]    public MoveToTarget moveToTArget;
    [HideInInspector]    public Attack attack;
    [HideInInspector]    public CharacterSettings settings;
	public int id;

    void Start()
    {
        stats = GetComponent<CharacterStats>();
        moveToTArget = GetComponent<MoveToTarget>();
        attack = GetComponent<Attack>();
        settings = GetComponent<CharacterSettings>();

        OnStart();
    }

    public states state;
    public enum states
    {
        ALIVE,
        DEAD
    }
    public actions action;
    public enum actions
    {
        MOVEING_TO_TARGET,
        ATTACKING,
        IDLE
    }
    void FixedUpdate()
    {
        if (state != states.ALIVE) return;
        OnFixedUpdate();
    }
    public void Alive()
    {
        if (state == states.ALIVE) return;
        state = states.ALIVE;
    }
    public void Dead()
    {
        if (state == states.DEAD) return;
        state = states.DEAD;
        Events.OnCharacterDie(this);

		OnDie ();
    }
    public virtual void OnStart() { }
    public virtual void OnAreaViewActive(Character character)  { }
	public virtual void OnAreaViewOff(Character character)  { }
    public virtual void OnFixedUpdate()  { }
    public virtual void OnEnterAttackMode() { }
    public virtual void OnEnemyKilled() { }
	public virtual void OnDie() { }
    
    public void Attacked(int qty)
    {
        stats.RemoveEnergy(qty);
    }
}
