using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AndreyTest
{
    public class EnemyStats : MonoBehaviour
    {
        //EnemyStats -> igual que PlayerStats pero para enmigos

        public int healthLevel = 10;
        public int maxHealth;
        public int currentHealth;

        Animator animator;

        private void Awake()
        {
            animator = GetComponentInChildren<Animator>();
        }

        // Start is called before the first frame update
        void Start()
        {
            maxHealth = SetMaxHealthFromHelathLevel(); // set la vida maxima que tendra el enemigo dependido del healthLevel
            currentHealth = maxHealth; //indico al iniciar que la vida esta al maximo
        }

        private int SetMaxHealthFromHelathLevel()
        {
            maxHealth = healthLevel * 10;
            return maxHealth;
        }

        public void TakeDamage(int damage) //funcion que te reduce la vida respecto al danyo que recibes
        {
            currentHealth = currentHealth - damage;  // vida actual - el daño que te hacen

            animator.Play("Damage_01"); //activar animacion de danyo

            if (currentHealth <= 0) //si la vida llega a 0
            {
                currentHealth = 0;
                animator.Play("Dead_01");
            }
        }
    }
}

