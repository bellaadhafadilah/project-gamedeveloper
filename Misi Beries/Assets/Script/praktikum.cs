using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class praktikum : MonoBehaviour
{
    public int health = 100;
    float speed = 5.5f;
    bool isAlive = true;
    string namaPlayer = "Sadako";
    char grade = 'A';
    // Start is called before the first frame update
    void Start()
    {
//percobaan ke 1
        //Debug.Log("Health Player : " + health);
        //int damage = 20;
        //health = health - damage;
        //Debug.Log("Darah Sekarang " + health);

        //bool isDead = (health <= 0);
        //Debug.Log("Apakah player mati? " + isDead);

        //if(isAlive && health > 0)
        //{
            //Debug.Log("Pemain masih hidup");
        //}
        //else
        //{
            //Debug.Log("Pemain telah mati");
        //}  

//percobaan ke 2
        // if (health > 50)
        // {
        //     Debug.Log(namaPlayer + "Masih Kuat");           
        // }else if (health > 0)
        // {
        //     Debug.Log("Hati hati");
        // }
        // else 
        // {
        //     Debug.Log(namaPlayer + "Telah mati");
        //     isAlive = false;
        // }
//percobaan ke 3
        // for (int i = 1; i <=5; i++)
        // {
        //     Debug.Log("Hit ke- " + ) BELUM SELESE
        // }
//percobaan ke 4
        // int[] scores = {100, 80, 60, 40, 20};
        // foreach (int score in scores)
        // {
        //     Debug.Log("Skor " + ) BELUM SELSE
        // }
//percobaan ke 5
        // GetPlayerStatus(20);
//percobaan ke 6
        // StartCoroutine(contohCorotine(2f));
//percobaan ke 7
        string status = GetPlayerStatus(40);
        Debug.Log("Status Pemain " + status);
    }

//percobaan ke 5
    // public void GetPlayerStatus(int damage)
    // {
    //     health = health - damage;
    //     Debug.Log("Darah Sekarang = " + health);
    // }

//percobaan ke 6
    // IEnumerator contohCorotine(float waktu)
    // {
    //     Debug.Log("Mulai Corotine");
    //     yield return new WaitForSeconds(waktu);
    //     Debug.Log("Corotine Selesai");
    // }

//percobaan ke 7
    string GetPlayerStatus(int darah)
    {
        if (darah > 50)
            return "Hidup";
        else if (darah > 0)
            return "Lemah";
        else
            return "Mati";
    }

}

