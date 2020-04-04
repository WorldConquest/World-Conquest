using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Stat healthPlayer;
    
    [SerializeField]
    private Stat shieldPlayer;

    [SerializeField]
    private Stat healthEnemy;

    [SerializeField]
    private Stat shieldEnemy;

    [SerializeField]
    private GameObject attackEffectInEnemy;

    [SerializeField]
    private GameObject deathEffectInEnemy;
    
    private void Awake()
    {
        healthPlayer.Initialize();
        shieldPlayer.Initialize();
        healthEnemy.Initialize();
        shieldEnemy.Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        // Management of the player's life
        if (Input.GetKeyDown(KeyCode.Q))
        {
            healthPlayer.CurrentVal -= 10;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            healthPlayer.CurrentVal += 10;
        }

        // Management of the player's shield
        if (Input.GetKeyDown(KeyCode.Z))
        {
            shieldPlayer.CurrentVal -= 10;
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            shieldPlayer.CurrentVal += 10;
        }



        // Management of the enemy's life
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (shieldEnemy.CurrentVal > 0)
            {
                shieldEnemy.CurrentVal -= 10;
                // Occurrence of explosion
                Instantiate(attackEffectInEnemy, new Vector3(170, 10, 142), Quaternion.identity);
            }
            else
            {
                healthEnemy.CurrentVal -= 10;
                // Occurrence of explosion
                Instantiate(attackEffectInEnemy, new Vector3(170, 10, 142), Quaternion.identity);
            }
            if (healthEnemy.CurrentVal <= 0)
            {
                // Occurrence of explosion of death
                Instantiate(deathEffectInEnemy, new Vector3(170, 10, 142), Quaternion.identity);
            }
        }

        // Management of the enemy's shield
    }
}
