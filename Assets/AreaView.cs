using UnityEngine;
using System.Collections;

public class AreaView : MonoBehaviour
{
    public Character character;
    public string area_to_react_name;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == area_to_react_name)
        {
			
            Character _other = other.gameObject.GetComponentInParent<Character>();
			if (character != null && _other != null)
                character.OnAreaViewActive(_other);
			print ("entra " + _other);
        }
    }
	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.name == area_to_react_name)
		{
			Character _other = other.gameObject.GetComponentInParent<Character>();
			if (character != null && _other != null)
				character.OnAreaViewOff(_other);
			print ("sale  " + _other);
		}
	}
}
