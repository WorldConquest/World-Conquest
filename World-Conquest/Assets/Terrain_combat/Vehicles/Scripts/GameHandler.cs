using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using CodeMonkey; // Namespace pour les boutons CMDebug.ButtonUI

public class GameHandler : MonoBehaviour
{
    public Transform pfHealthBar;
    public Button Attack_Button;
    public Button Heal_Button;
    public HealthSystem healthSystem = new HealthSystem(100);

    // Start is called before the first frame update
    void Start()
    {
        Transform healthBarTransform = Instantiate(pfHealthBar, new Vector3(19, 3, 8), Quaternion.Euler(0, 225, 0));
        healthBarTransform.transform.localScale = new Vector3(0.2f, 0.2f, 0);
        HealthBar healthBar = healthBarTransform.GetComponent<HealthBar>();
        healthBar.Setup(healthSystem);

        
        Button buttonAttack = Attack_Button.GetComponent<Button>();//Récupération du bouton d'attaque
        buttonAttack.onClick.AddListener(Attack);//Ajout d'une écoute sur le bouton d'attaque


        Button buttonHeal = Heal_Button.GetComponent<Button>();//Récupération du bouton de soin
        buttonHeal.onClick.AddListener(Heal);//Ajout d'une écoute sur le bouton de soin
    }
    public void Attack()
    {
        healthSystem.Damage(10); // Dégat de 10 points de vie
        Debug.Log("Dégat : " + healthSystem.GetHealth());
    }
    public void Heal()
    {
        healthSystem.Heal(10); // Soin de 10 points de vie
        Debug.Log("Soin : " + healthSystem.GetHealth());
    }
}
