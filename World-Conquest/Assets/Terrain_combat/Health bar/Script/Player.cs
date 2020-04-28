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
    private GameObject attackEffectInPlayer;

    [SerializeField]
    private GameObject deathEffectInEnemy;

    [SerializeField]
    private Destruction destructionEnemy;
   

    //Effects vector variable Enemy
    [SerializeField]
    private float vectorEnemyX = 170;

    [SerializeField]
    private float vectorEnemyY = 10;

    [SerializeField]
    private float vectorEnemyZ = 142;

    //Effects vector variable Ally
    [SerializeField]
    private float vectorAllyX = 150;

    [SerializeField]
    private float vectorAllyY = 10;

    [SerializeField]
    private float vectorAllyZ = 142;

    [SerializeField]
    private Destruction destructionPlayer1;

    [SerializeField]
    private Destruction destructionPlayer2;

    [SerializeField]
    private Destruction destructionPlayer3;

    [SerializeField] // Need for stop move when player die
    private Vehicle_move_plane Vehicle_move_plane;

    [SerializeField] // Need for stop move when player die
    private Vehicle_move_boat Vehicle_move_boat;

    [SerializeField] // Need for stop move when player die
    private Vehicle_move_tank Vehicle_move_tank;

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
                Instantiate(attackEffectInEnemy, new Vector3(vectorEnemyX, vectorEnemyY, vectorEnemyZ), Quaternion.identity);
            }
            else
            {
                healthEnemy.CurrentVal -= Random.Range(1, 50);
                // Occurrence of explosion
                Instantiate(attackEffectInEnemy, new Vector3(vectorEnemyX, vectorEnemyY, vectorEnemyZ), Quaternion.identity);
            }
            if (healthEnemy.CurrentVal <= 0)
            {
                // Occurrence of explosion of death
                Instantiate(deathEffectInEnemy, new Vector3(vectorEnemyX, vectorEnemyY, vectorEnemyZ), Quaternion.identity);
                destructionEnemy.DestructionObject();

            }
        }

        // Management of the ally life
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (shieldPlayer.CurrentVal > 0 && healthPlayer.CurrentVal > 0)
            {
                shieldPlayer.CurrentVal -= Random.Range(1, 50);
                // Occurrence of explosion
                Instantiate(attackEffectInPlayer, new Vector3(vectorAllyX, vectorAllyY, vectorAllyZ), Quaternion.identity);
            }
            else
            {
                healthPlayer.CurrentVal -= Random.Range(1, 50);
                // Occurrence of explosion
                Instantiate(attackEffectInPlayer, new Vector3(vectorAllyX, vectorAllyY, vectorAllyZ), Quaternion.identity);
            }
            if (healthPlayer.CurrentVal <= 0)
            {
                // Occurrence of explosion of death
                Instantiate(deathEffectInEnemy, new Vector3(vectorAllyX, vectorAllyY, vectorAllyZ), Quaternion.identity);

                // Boat vehicle
                destructionPlayer1.DestructionObject();
                Vehicle_move_boat.tangageMoins = 0f; // Allow to stop move vehicles
                Vehicle_move_boat.tangagePlus = 0f; // Allow to stop move vehicles

                // Plane vehicle
                destructionPlayer2.DestructionObject();
                Vehicle_move_plane.altitudeMoins = 0f; // Allow to stop move vehicles
                Vehicle_move_plane.altitudePlus = 0f; // Allow to stop move vehicles

                // Tank vehicle
                destructionPlayer3.DestructionObject();
                Vehicle_move_tank.speedMoins = 0f; // Allow to stop move vehicles
                Vehicle_move_tank.speedPlus = 0f; // Allow to stop move vehicles
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
        if (healthPlayer.CurrentVal <= 0)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 65, Screen.height / 2 - 80, 140, 80), "You lose..."))
            {
                //SceneManager.LoadScene("CityBuilder");
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 170, Screen.height / 2 + 70, 110, 80), "Try again ?"))
            {
                SceneManager.LoadScene("TankArena");
            }
            if (GUI.Button(new Rect(Screen.width / 2 + 70, Screen.height / 2 + 70, 110, 80), "City builder"))
            {
                SceneManager.LoadScene("CityBuilder");
            }
        }
    }
}
