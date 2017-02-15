using UnityEngine;
using System.Collections;

public class MoveToTarget : MonoBehaviour {
    
    public Transform target;
	private float realSpeed;
    private Enemy enemy;

    public void Init(Enemy enemy)
    {
        this.enemy = enemy;       
    }
	public void FixedUpdateByManager(float _speed)
    {
        if (target == null) return;
        float step = _speed/10 * Time.deltaTime;
         transform.position = Vector3.MoveTowards(transform.position, target.position, step);

		Vector3 direction = transform.position - target.transform.position;
		Quaternion toRotation = Quaternion.LookRotation(direction);
		toRotation.x = 0;
		toRotation.z = 0;
		transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, 2.5f * Time.deltaTime);

    }
    void OnTriggerEnter(Collider col)
    {
		if (enemy == null)
			return;
        if(col.tag == "pathfinderNode")
        {
            enemy.OnReachPathNode(col.GetComponent<PathFinderNode>());
        }
    }
}
