using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{   
    // VARIABLES
    // player health
    [Tooltip("Max Health Pawn can have.")] public float maxHealth;
    [Tooltip("Initial, Starting Health Pawn has.")] public float initialHealth;
    private float deciHealth;
    public bool pRentry = false;

    // Object Variables
    private RagdollControl rd;
    private Enemy ai;

    // Start is called before the first frame update
    private void Start()
    {
        rd = GetComponent<RagdollControl>();
        ai = GetComponent<Enemy>();
    }

    // Update is called once per frame
    private void Update()
    {
        // if gameobjects health is more or less than max health
        if(initialHealth > maxHealth)
        {
            // if more set health to maxhealth
            initialHealth = maxHealth;
        }
        if(initialHealth <= 0)
        {
            if (GameManager.preventRentry == false)
            {
                Debug.Log("Calling");
                GameManager.preventRentry = true;
                // if less than call OnDeath()
                initialHealth = 0;
                OnDeath();
                return;
            }
            if(gameObject.CompareTag("Enemy"))
            {
                initialHealth = 0;
                OnDeath();
                return;
            }
        }
    }
    // function to return decimal value to UI to set health percentage to canvas
    public float HealthPercent()
    {
        deciHealth = initialHealth / maxHealth;
        return deciHealth;
    }
    // if healthpickup heal gameobjects health, health value passed to here
    public void AddHealth(float healing)
    {
        initialHealth += healing;
    }
    // function to cover damage to gameobjects health, damage value passed to here
    public void DamageToHealth(float damage)
    {
        initialHealth -= damage;
    }
    // function to call destroy gameobject when health is less than or equal to 0
    public void OnDeath()
    {
        if(gameObject.CompareTag("Player"))
        {
            GameManager.isDead = true;
        }
        if(gameObject.CompareTag("Enemy"))
        {
            Destroy(this);
            ai.isDead = true;
            ai.OnDie();
        }
        rd.isDead = true;
    }
}
