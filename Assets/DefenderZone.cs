using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class DefenderZone : MonoBehaviour {

    public List<Character> enemiesNear;
	public Defender defender;
	public List<Defender> defenders;
	private int totalDefenders = 3;

    void Start()
    {
        Events.OnCharacterDie += OnCharacterRemove;
        Loop();
    }
    void OnCharacterRemove(Character character)
    {
        Character characterToRemove = null;
        foreach (Character ch in enemiesNear)
            if (ch == character)
                characterToRemove = ch;
		if (characterToRemove)
			enemiesNear.Remove (characterToRemove);
		else {
			foreach (Character ch in defenders)
				if (ch == character)
					characterToRemove = ch;
			if (characterToRemove)
				defenders.Remove (characterToRemove.GetComponent<Defender>());
		}
    }
    public void SetGravity(Transform target)
    {
        transform.LookAt(target);
    }
    public void OnEnemyEnterZone(Character character)
    {
        Enemy enemy = character.GetComponent<Enemy>();
        if (!enemy) return;
        foreach (Character ch in enemiesNear)
            if (ch == enemy) return;
        enemiesNear.Add(enemy);
    }
    public void OnEnemyExitZone(Character character)
    {
        OnCharacterRemove(character);
    }
    void Loop()
    {
		if (enemiesNear.Count > 0 && defenders.Count<totalDefenders)
        {
            Vector3 pos = transform.position;
           // pos.y += 0.01f;
			Vector3 Promedio = (enemiesNear[0].transform.position + transform.position) / 2;
			OnAddDefender(Promedio);           
        }
        Invoke("Loop", World.Instance.settings.defenseZone.fofrequency_to_spawn);
    }
	void OnAddDefender(Vector3 pos) {		
		Defender newDefender = Instantiate(defender);
		newDefender.transform.SetParent (World.Instance.world.transform);
		newDefender.transform.position = pos;
		defenders.Add (newDefender);
	}
}
