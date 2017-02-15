using UnityEngine;
using System.Collections;

public static class Events
{
    public static System.Action ResetApp = delegate { };
    
    public static System.Action<string> GotoTo = delegate { };
    public static System.Action<string> GotoBackTo = delegate { };
    public static System.Action Back = delegate { };

    public static System.Action<Vector3> OnAddDefenseZone = delegate { };
    public static System.Action<Vector3> OnAddDefender = delegate { };
	public static System.Action<Tower> OnTeleport = delegate { };

    public static System.Action OnLeftTriggerPress = delegate { };
	public static System.Action OnLeftTriggerRelease = delegate { };

    public static System.Action<Character> OnCharacterDie = delegate { };

	public static System.Action<int> OnMoneyUpdate = delegate { };
	public static System.Action<Vector3, int> OnEnemyHurt = delegate { };
	public static System.Action<int> OnMoneyUpdated = delegate { };
}
   
