using System;


public class HealthSystem
{
   public event EventHandler OnHealthChanged; // Évenement lors du la vie change

   private int health;
   private int healthMax;

   public HealthSystem(int healthMax)
    {
        this.healthMax = healthMax;
        health = healthMax;
    }

    // Fonction de récupération du nombre de point de vie
    public int GetHealth()
    {
        return health;
    }

    // Fonction pour récupérer le pourcentage de vie
    public float GetHealthPercent()
    {
        return (float)health / healthMax;
    }

    // Fonction de dégat
    public void Damage(int damageAmount)
    {
        health -= damageAmount; 
        // Permet de pas passer en dessous de 0
        if (health < 0)
        {
            health = 0;
        }
        // En cas de dégat, le OnHealthChanged n'est pas null, alors la vie change
        if (OnHealthChanged != null)
        {
            OnHealthChanged(this, EventArgs.Empty);
        }
    }

    // Fonction de soin
    public void Heal(int healAmount)
    {
        health += healAmount;
        // Permet de pas dépasser la vie max
        if (health > healthMax)
        {
            health = healthMax;
        }
        // En cas de soin, le OnHealthChanged n'est pas null, alors la vie change
        if (OnHealthChanged != null)
        {
            OnHealthChanged(this, EventArgs.Empty);
        }
    }
}
