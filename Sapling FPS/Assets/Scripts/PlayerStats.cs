using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{

    private void Start()
    {
        maxHp = 100;
        hp = maxHp;

        maxStamina = 100;
        stamina = maxStamina;
    }

    public override void Die()
    {
        Debug.Log("You ded");
    }
}
