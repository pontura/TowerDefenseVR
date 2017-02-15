using UnityEngine;
using System.Collections;
using System;

public class Settings : MonoBehaviour {
	
    public int weaponForce = 6;
    public Character enemies;
    public Character defenders;
    public DefenseZone defenseZone;
    public Spawn spawn_enemies;
	public User user;
	public Prices prices;

	[Serializable]
	public class User
	{
		public int initialMoney = 100;
	}
	[Serializable]
	public class Prices
	{
		public int defenderBow = 25;
		public int defenderSoldiers = 50;
		public int hurtEnemy = 10;
	}

    [Serializable]
    public class Spawn
    {
        public float time_to_spawn = 1;
        public int total = 10;
		public int wait_to_respawn = 10;
    }

    [Serializable]
    public class Character
    {
		public int bow_damage = 25;
        public int force = 1;
        public int speed_to_run = 1;
        public int speed_to_target = 1;
        public float frequency_to_attack = 0.5f;
    }
    [Serializable]
    public class DefenseZone
    {
        public float fofrequency_to_spawn = 1;
    }

}
