using UnityEngine;
using System.Collections;

public class AreaDefenseZone : MonoBehaviour
{
    public DefenderZone zone;
    public string area_to_react_name;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == area_to_react_name)
        {
            Character _other = other.gameObject.GetComponentInParent<Character>();
            if (_other == null) return;
            zone.OnEnemyEnterZone(_other);
        }
    }
    void OnTriggerExit(Collider other)
    {
        Character _other = other.gameObject.GetComponentInParent<Character>();
        if (_other != null)
            zone.OnEnemyExitZone(_other);
    }
}
