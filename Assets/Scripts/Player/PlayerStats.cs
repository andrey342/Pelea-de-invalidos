using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AndreyTest
{
    public class PlayerStats : MonoBehaviour
    {
        //PlayerStats -> centro de control de las estadisticas del personaje
        //Aca se controla todo lo que tiene que ver con la vida, por ejemplo
        //cuando golpean al personaje y hay que bajarle la vida, hacer una aniamcion de danyo
        // cuando el persoanje muere hacer animacion ...

        public int healthLevel = 10;
        public int maxHealth;
        public int currentHealth;

        public HealthBar healthBar;

        AnimatorHandler animatorHandler; //para pasarle las animaciones al centro de control

        private void Awake()
        {
            animatorHandler = GetComponentInChildren<AnimatorHandler>();
        }

        // Start is called before the first frame update
        void Start()
        {
            maxHealth = SetMaxHealthFromHelathLevel(); // set la vida maxima que tendra el personaje dependido del healthLevel
            currentHealth = maxHealth; //indico al iniciar que la vida esta al maximo
            healthBar.SetMaxHealth(maxHealth); //le indico a la barra de saluda su valor
        }

       private int SetMaxHealthFromHelathLevel()
        {
            maxHealth = healthLevel * 10;
            return maxHealth;
        }

        public void TakeDamage(int damage) //funcion que te reduce la vida respecto al danyo que recibes
        {
            currentHealth = currentHealth - damage;  // vida actual - el daño que te hacen

            healthBar.SetCurrentHealth(currentHealth); // actualizar la salud

            animatorHandler.PlayTargetAnimation("Damage_01", true); //activar animacion de danyo

            if(currentHealth <= 0)
            {
                currentHealth = 0;
                animatorHandler.PlayTargetAnimation("Dead_01", true);
            }
        }
    }

}
