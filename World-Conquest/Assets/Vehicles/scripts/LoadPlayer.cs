using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPlayer : MonoBehaviour
{

    public GameObject[] Player;

    void Start()
    {
        string P = PlayerPrefs.GetString("Player");

        for(int i=0; i<Player.Length; i++)
        {
            if(P+" (UnityEngine.GameObject)"==Player[i].ToString())
            {
                Instantiate(Player[i], transform.position, Quaternion.identity);
            }
        }
    }
}
