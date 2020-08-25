using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryAndStats 
{
    public static int currency;
    public static bool key;
    public static float damage = 2;

    public static float GetDamage()
    {
        return damage;
    }
    public static void SetDamage(float addedDamage)
    {
        damage += addedDamage;
    }

    public static int GetCurrency()
    {
        return currency;
    }

    public static void SetCurrency(int newCurrency)
    {
        currency += newCurrency; 
    }
    public static void SetKey(bool haveKey)
    {
        key = haveKey;
    }
    public static bool GetKey()
    {
        return key;
    }
}
