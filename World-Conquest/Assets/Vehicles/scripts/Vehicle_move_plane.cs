using System.Diagnostics;
using System.ComponentModel;
using System; //Fonction random
using System.Timers; //Fonction Timer
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle_move_plane: MonoBehaviour
{
     /*
     * -------------------- Définition des variables --------------------
     */
    //La variable start permet d'avancer les véhicules jusqu'à la zone de combat après elle passe à false 
    private bool start = true;
    //Définition du vecteur direction (sur un plan 3D on utilisera seulement l'axe des y)
    private Vector3 moveDirection = Vector3.zero;
    //Composant permettant le déplacment de l'objet (à installer au préalable sur l'objet hôte du code)
    CharacterController Cc;

    //Les différentes variables liées aux véhicules
    public float debutAleaGen      = +0f;
    public float delaiEntreAleaGen = +0.5f;
    public float placementDefautX  = +15f;
    public float limiteZCombatInfY = +2f;
    public float limiteZCombatSupY = +4f;
    private float speed;
    public float speedInit = +3f;
    private float altitude;
    public float altitudeMoins = -1f;
    public float altitudePlus  = +1f;
    private float altitudeBornes;
    public float altitudeBorneMoins = +0.1f;
    public float altitudeBornePlus  = +1f;



    /*
     * #################### Lancement de la fonction principale ####################
     * Appelée lors du lancement (1 seule fois)
     */
    void Start()
    {
        //Appel de la fonction permettant le déplacement des objets grâce au composant Character controller
        Cc = GetComponent<CharacterController>();
        //Répète la fonction RandomSpeed du moment 0f tous les 0.5f les valeurs peuvent être changées
        InvokeRepeating("RandomSpeed", debutAleaGen, delaiEntreAleaGen);
    }

    /*
    * #################### Lancement de la fonction changer de vitesse ####################
    */
    void RandomSpeed()
    {
        //Génération aléatoire des différentes valeurs de vitesse
        altitude       = UnityEngine.Random.Range(altitudeMoins, altitudePlus);
        altitudeBornes = UnityEngine.Random.Range(altitudeBorneMoins, altitudeBornePlus);
    }
    /*
    * #################### Lancement de la fonction d'actualisation ####################
    */
    void Update()
    {
        //Actualisation de la position du véhicule
        Cc.Move(moveDirection * Time.deltaTime);
        moveDirection = new Vector3(0, altitude, speed);

        if(start == false)
        {
            //Modification de la vitesse initiale
            speed = 0;
            //Test de la hauteur de l'avion
            if(transform.position.y >= limiteZCombatInfY && transform.position.y <= limiteZCombatSupY)
            {
                moveDirection = transform.TransformDirection(moveDirection);
            }
            else
            {
                //Si la hauteur atteint la borne inférieure on fait monter l'avion
                if(transform.position.y < limiteZCombatInfY)
                {
                    altitude      = altitudeBornes;
                    moveDirection = transform.TransformDirection(moveDirection);

                }
                else
                {  
                    altitude      = altitudeBornes * -1;
                    moveDirection = transform.TransformDirection(moveDirection);
                }
            }
        }
        else
        {
            //Phase d'initialisation quand start = true
            speed = speedInit;
            if(transform.position.y > limiteZCombatSupY)
            {
                altitude      = -3;
                moveDirection = transform.TransformDirection(moveDirection);
            }
            else
            {
                altitude      = +1;
                moveDirection = transform.TransformDirection(moveDirection);
            }

            if(transform.position.x < placementDefautX)
            {
                start = false;
            }
        }
  
        
    }
}

//UnityEngine.Debug.Log(transform.position.y);