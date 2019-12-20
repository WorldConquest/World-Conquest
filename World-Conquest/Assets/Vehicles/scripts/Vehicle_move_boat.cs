using System.Runtime.CompilerServices;
using System.Diagnostics;
using System.ComponentModel;
using System; //Fonction random
using System.Timers; //Fonction Timer
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle_move_boat : MonoBehaviour
{
    public  Boolean start         = true;
    //Définition du vecteur direction (sur un plan 3D on utilisera seulement l'axe des x)
    private Vector3 moveDirection = Vector3.zero;
    //Composant permettant le déplacment de l'objet (à installer au préalable sur l'objet hôte du code)
    CharacterController Cc;

    //Les différentes vitesses de déplacement des véhicules
    //Gravitée appliquée aux véhicules
    public  float gravity         = 20f;
    public float debutAleaGen = 0f;
    public float delaiEntreAleaGen = 8f;
    public float placementDefautX = 15f;
    public float limiteTangageGauche = -0.10f;
    public float limiteTangageDroite = 0.10f;
    private float speed;
    public float speedInit = 1f;
    private float tangage;
    public float tangageMoins = -0.7f;
    public float tangagePlus = 0.7f;
    private float tangageBornes;
    public float tangageBorneMoins = 0.1f;
    public float tangageBornePlus = 0.3f;

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
        tangage     = UnityEngine.Random.Range(tangageMoins, tangagePlus);
        tangageBornes     = UnityEngine.Random.Range(tangageBorneMoins, tangageBornePlus);
    }

    void Update()
    {
        //Ajout de la gravité au véhicule
        moveDirection.y -= gravity * Time.deltaTime;
        //Actualisation de la position du véhicule
        Cc.Move(moveDirection * Time.deltaTime);

        if(Cc.isGrounded)
        {
            moveDirection = new Vector3(0, 0, speed);
            if(start == false)
            {
                //Changer le sens de la balise si l'arène est rotate 
                if(transform.position.x >= placementDefautX)
                {
                    speed = 0;
                    moveDirection = transform.TransformDirection(moveDirection);

                    if(transform.rotation.z >= limiteTangageGauche && transform.rotation.z <= limiteTangageDroite)
                    {
                        transform.Rotate(0, 0, tangage);   
                    }
                    else
                    {
                        if(transform.rotation.z < limiteTangageGauche)
                        {
                            tangage = tangageBornes;
                            transform.Rotate(0, 0, tangage);
                        }
                        else
                        {
                            tangage = tangageBornes * -1;
                            transform.Rotate(0, 0, tangage);
                        }
                    }

                }
            }
            else
            {
                speed = speedInit;
                moveDirection = transform.TransformDirection(moveDirection);
                //Changer le sens de la balise si l'arène est rotate
                if(transform.position.x > placementDefautX)
                {
                    start = false;
                }
            }
        }

    }
}

//                    UnityEngine.Debug.Log(transform.rotation.z);