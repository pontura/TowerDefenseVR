using UnityEngine;
using System.Collections;

public class AttackBow : Attack {

    public Transform body;
    public Proyectil proyectil;
	private int malaPunteria = 4;
	public Animator anim;

    public override void FixedUpdateByManager()
    {
        if (target == null)
            return;
        body.LookAt(target.transform);
        Vector3 rot = body.transform.localEulerAngles;
        rot.x = 0;  rot.y = 0;
        body.transform.localEulerAngles = rot;
    }
    void Shoot()
    {
        if (target == null)
        {
            character.OnEnemyKilled();
            return;
        }
		anim.Play ("shoot");
        Proyectil newProyectil = Instantiate(proyectil);
		newProyectil.transform.SetParent (World.Instance.world.transform);
		newProyectil.transform.position = transform.position;

		Vector3 targetPos = target.transform.position;
		//altura del enemy:
		targetPos.y += 1.5f;
		targetPos.x += Random.Range (0, malaPunteria)-(malaPunteria/2);
		targetPos.z += Random.Range (0, malaPunteria)-(malaPunteria/2);

		newProyectil.transform.LookAt (targetPos);
		newProyectil.Init(newProyectil.transform.forward, World.Instance.settings.weaponForce);
    }
    public override void Loop()
    {
		if(character != null && character.action == Character.actions.ATTACKING)
       	 	Shoot();
        CancelInvoke();
        Invoke("Loop", character.settings.frequency_to_attack);
    }
}
