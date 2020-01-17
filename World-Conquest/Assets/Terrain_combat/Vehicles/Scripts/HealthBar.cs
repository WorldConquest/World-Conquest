using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private HealthSystem healthSystem;

    public void Setup(HealthSystem healthSystem)
    {
        this.healthSystem = healthSystem;

        healthSystem.OnHealthChanged += healthSystem_OnHealthChanged;
    }

    private void healthSystem_OnHealthChanged(object sender, System.EventArgs e)
    {
        transform.Find("Bar").localScale = new Vector3(healthSystem.GetHealthPercent(), 1);
    }

    private void Update()
    {
        //Performance trop impacter par un refresh update a chaque frame donc on fait autrement avec la fonction au dessus
        //transform.Find("Bar").localScale = new Vector3(healthSystem.GetHealthPercent(), 1);
    }
}
