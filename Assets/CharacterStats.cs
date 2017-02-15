using UnityEngine;
using System.Collections;

public class CharacterStats : MonoBehaviour {

    private int energy = 100;
    Character character;
    public ProgressBar bar;

    void Start()
    {
        character = GetComponent<Character>();
    }
    public void SetBar()
    {
        bar.SetValue((float)energy / 100);
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
    }
}
