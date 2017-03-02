using UnityEngine;
using System.Collections;

public class CharacterStats : MonoBehaviour {
	
	private int totalEnergy;
    private int energy;
    Character character;
    public ProgressBar bar;

    void Start()
    {
        character = GetComponent<Character>();
    }
	public void SetEnergy(int _totalEnergy)
	{
		this.totalEnergy = _totalEnergy;
		this.energy = _totalEnergy;
	}
    public void SetBar()
    {		
		float n = ((float)energy / (float)totalEnergy);
        bar.SetValue(n);
    }

    public void RemoveEnergy(int qty)
    {
        energy -= qty;
        if (energy <= 0)
            EnergyEmpty();
        else
            SetBar();
    }
    void EnergyEmpty()
    {
        energy = 0;
		if (character == null)
			return;
        character.Dead();
		bar.transform.gameObject.SetActive (false);
    }
}
