using System.Diagnostics;
using System.ComponentModel;
using System; //Fonction random
using System.Timers; //Fonction Timer
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Vehicle_move_tank: MonoBehaviour
{   
    /*
     * -------------------- Définition des variables --------------------
     */
    //La variable start permet d'avancer les véhicules jusqu'à la zone de combat après elle passe à false 
    public Boolean start = true;
    //Définition du vecteur direction (sur un plan 3D on utilisera seulement l'axe des x)
    private Vector3 moveDirection = Vector3.zero;
    //Composant permettant le déplacment de l'objet (à installer au préalable sur l'objet hôte du code)
    CharacterController Cc;
    
    //Les différentes variables liées aux véhicules
    //Gravitée appliquée aux véhicules
    public float gravity           = +20f;
    public float debutAleaGen      = 0f;
    public float delaiEntreAleaGen = +10f;
    public float limiteZCombatInfX  = +17f;
    public float limiteZCombatSupX  = +13f;
    private float speed;
    public float speedInit  = +2f;
    public float speedMoins = -1f;  //Valeur de vitesse la plus basse générée dans la zone de combat
    public float speedPlus  = +1f;  //Valeur de vitesse la plus haute générée dans la zone de combat
    private float speedBornes;
    public float speedBornePlus  = +0.6f;  //Valeur de vitesse la plus haute générée aux bornes de la zone de combat
    public float speedBorneMoins = +0.1f;  //Valeur de vitesse la plus basse générée aux bornes de la zone de combat

    /*
     * #################### Lancement de la fonction principale ####################
     * Appelée lors du lancement (1 seule fois)
     */
    void Start()
    {
        //Appel de la fonction permettant le déplacement des objets grâce au composant Character controller
        Cc = GetComponent<CharacterController>();
        //Répète la fonction RandomSpeed du moment 0f tous les 10f les valeurs peuvent être changées
        InvokeRepeating("RandomSpeed", debutAleaGen, delaiEntreAleaGen);
    }

    /*
    * #################### Lancement de la fonction changer de vitesse ####################
    */
    void RandomSpeed()
    {
        //Génération aléatoire des différentes valeurs de vitesse
        speed      = UnityEngine.Random.Range(speedMoins, speedPlus);
        speedBornes = UnityEngine.Random. Range(speedBorneMoins, speedBornePlus);
    }

    /*
    * #################### Lancement de la fonction d'actualisation ####################
    */
    void Update()
    {
        //Ajout de la gravité au véhicule
        moveDirection.y -= gravity * Time.deltaTime;
        //Actualisation de la position du véhicule
        Cc.Move(moveDirection * Time.deltaTime);
        //Si le véhicule est au sol
        if(Cc.isGrounded)
        {
            //Instantiation du vecteur avec comme paramètre la vitesse speed 
            moveDirection = new Vector3(0, 0, speed);
            //Les véhicules sont dans la zone de combat start est à false
            if(start == false)
            {
                //Si le véhicule est dans la zone de combat
                if(transform.position.x <= limiteZCombatInfX && transform.position.x >= limiteZCombatSupX)
                {
                    //La vitesse s'actualise quelque soit la position du véhicule
                    moveDirection = transform.TransformDirection(moveDirection);
                }
                else
                {
                    //Si le véhicule tape la bordure de la zone de combat
                    if(transform.position.x < limiteZCombatSupX)
                    {
                        //Génération aléatoire d'une vitesse négative le véhicule recule
                        speed         = speedBornes * -1;
                        moveDirection = transform.TransformDirection(moveDirection);
                    }
                    else
                    {
                        //Génération aléatoire d'une vitesse positive le véhicule avance
                        speed         = speedBornes;
                        moveDirection = transform.TransformDirection(moveDirection);
                    }
                }
            }
            //Réalisation de la phase d'initialisation quand start vaut true
            else
            {
                    //Vitesse de déplacement  initiale constante
                    speed         = speedInit;
                    moveDirection = transform.TransformDirection(moveDirection);
                    //Dès que le véhicule est dans la zone de combat changement de l'état de la variable start
                    if(transform.position.x < limiteZCombatInfX)
                    {
                        start = false;
                    }
                    
            }

        }
    

    }


}


// Permet d'afficher la position du véhicule sur l'axe x permet le débuggage    UnityEngine.Debug.Log(transform.position.x);