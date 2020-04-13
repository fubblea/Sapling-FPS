using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int hp;
    public int maxHp;

    public int stamina;
    public int maxStamina;

    public bool isDead = false;

    private void CheckStamina()
    {
        if (stamina >= maxStamina)
        {
            stamina = maxStamina;
        }

        if (stamina <= 0)
        {
            stamina = 0;
        }
    }

    private void CheckHealth()
    {
        if (hp >= maxHp)
        {
            hp = maxHp;
        }

        if (hp <= 0)
        {
            hp = 0;
            isDead = true;
        }
    }

    public virtual void Die()
    {
        //Override
    }
}
