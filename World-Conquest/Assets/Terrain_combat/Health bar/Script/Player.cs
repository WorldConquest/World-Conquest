using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // 
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

    [SerializeField]
    private Destruction destructionEnemy;

    //Effects vector variable
    [SerializeField]
    private float vectorX = 170;

    [SerializeField]
    private float vectorY = 10;

    [SerializeField]
    private float vectorZ = 142;

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
            if (shieldEnemy.CurrentVal > 0 && healthEnemy.CurrentVal > 0)
            {
                shieldEnemy.CurrentVal -= Random.Range(1,50);
                // Occurrence of explosion
                Instantiate(attackEffectInEnemy, new Vector3(vectorX, vectorY, vectorZ), Quaternion.identity);
            }
            else
            {
                healthEnemy.CurrentVal -= Random.Range(1, 50);
                // Occurrence of explosion
                Instantiate(attackEffectInEnemy, new Vector3(vectorX, vectorY, vectorZ), Quaternion.identity);
            }
            if (healthEnemy.CurrentVal <= 0)
            {
                // Occurrence of explosion of death
                Instantiate(deathEffectInEnemy, new Vector3(vectorX, vectorY, vectorZ), Quaternion.identity);
                destructionEnemy.DestructionObject();

            }
        }
        // Management of the enemy's shield
    }
    void OnGUI()
    {
        if (healthEnemy.CurrentVal <= 0)
        {

            if (GUI.Button(new Rect(Screen.width / 2 - 80, Screen.height / 2 + 50, 140, 80), "You win !"))
            {
                SceneManager.LoadScene("CityBuilder");
            }

        }
    }
}
