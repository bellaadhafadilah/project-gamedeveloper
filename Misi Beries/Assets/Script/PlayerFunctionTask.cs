using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFunctionTask : MonoBehaviour
{
    public int playerHealth = 100;
    public int playerArmor = 20;
    public int playerDamage = 50;
    void Start()
    {
        // Panggil semua fungsi
        string status = GetPlayerStatus();
        int effectiveDamage = CalculateEffectiveDamage(playerDamage);
        bool isAlive = IsPlayerAlive();

        // Tampilkan hasilnya di Console Unity
        Debug.Log("Status Player : " + status);
        Debug.Log("Damage Setelah Dikurangi Armor : " + effectiveDamage);
        Debug.Log("Apakah Player Masih Hidup? : " + isAlive);
    }

    // Fungsi 1 : Mengembalikan status berdasarkan Health
    string GetPlayerStatus()
    {
        if (playerHealth > 75)
        {
            return "Sehat";
        }
        else if (playerHealth > 40)
        {
            return "Cukup Sehat";
        }
        else if (playerHealth > 0)
        {
            return "Sekarat";
        }
        else
        {
            return "Mati";
        }
    }

    // Fungsi 2 : Mengurangi damage berdasarkan armor
    int CalculateEffectiveDamage(int damage)
    {
        int reducedDamage = damage - playerArmor;

        // Pastikan damage minimal 0 (tidak minus)
        if (reducedDamage < 0)
        {
            reducedDamage = 0;
        }

        return reducedDamage;
    }

    // Fungsi 3 : Mengembalikan true jika Health > 0
    bool IsPlayerAlive()
    {
        return playerHealth > 0;
    }
}
