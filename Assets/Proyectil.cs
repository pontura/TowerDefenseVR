using UnityEngine;
using System.Collections;

public class Proyectil : MonoBehaviour {
    
	bool reachEnemy;
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
		if (reachEnemy) return;
		transform.forward = Vector3.Slerp(transform.forward, rb.velocity.normalized, Time.deltaTime);
	}
    void OnCollisionEnter(Collision col)
    {
		if (reachEnemy)
			return;
		EnemyPart enemyPart = col.transform.gameObject.GetComponent<EnemyPart>();
		if (enemyPart != null) {
			reachEnemy = true;
			Enemy enemy= enemyPart.GetComponentInParent<Enemy> ();
			if (enemy == null) {
				Reset ();
				return;
			}
			CancelInvoke ();
			int bow_damage = World.Instance.settings.defenders.bow_damage;
			int hurtEnemy = World.Instance.settings.prices.hurtEnemy;

			Events.OnEnemyHurt (transform.position, bow_damage);
			Events.OnMoneyUpdate (hurtEnemy);

			enemy.Attacked (bow_damage);
			//Reset ();
			GetComponent<Rigidbody> ().isKinematic = true;
			GetComponent<Collider> ().enabled = false;
			transform.SetParent (col.transform);
		} 
		GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
    void Reset()
    {
        Destroy(gameObject);
    }
}
