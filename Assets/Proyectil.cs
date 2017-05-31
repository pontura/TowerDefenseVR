using UnityEngine;
using System.Collections;

public class Proyectil : MonoBehaviour {
    
	bool reachTarget;
	Rigidbody rb;

    public void Init(Vector3 direction, float shootForce)
    {
		transform.forward = direction;
		shootForce /= 2;
		rb = GetComponent<Rigidbody> ();
		rb.velocity = (transform.forward * shootForce);
        Invoke("Reset", 2);
    }
	void Update()
	{
		if (reachTarget) return;
		transform.forward = Vector3.Slerp(transform.forward, rb.velocity.normalized, Time.deltaTime);
	}
    void OnCollisionEnter(Collision col)
    {
		if (reachTarget) return;
		CatchSomething ();
		EnemyPart enemyPart = col.transform.gameObject.GetComponent<EnemyPart>();
		if (enemyPart != null) {
			transform.SetParent (col.transform);
			OnReachedEnemy (enemyPart.GetComponentInParent<Enemy> ());	
		}	
		Bomb bomb = col.transform.gameObject.GetComponent<Bomb>();
		if (bomb != null) {			
			bomb.Explote ();
			Reset ();
		}	
    }
	void CatchSomething()
	{
		reachTarget = true;
		GetComponent<Rigidbody> ().isKinematic = true;
		GetComponent<Collider> ().enabled = false;
		GetComponent<Rigidbody>().velocity = Vector3.zero;
	}
	void OnReachedEnemy(Enemy enemy)
	{
		CancelInvoke ();
		int bow_damage = World.Instance.settings.defenders.bow_damage;
		int hurtEnemy = World.Instance.settings.prices.hurtEnemy;

		Events.OnEnemyHurt (transform.position, bow_damage);
		Events.OnMoneyUpdate (hurtEnemy);

		enemy.Attacked (bow_damage);
	}
    void Reset()
    {
        Destroy(gameObject);
    }
}
