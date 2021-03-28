using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : Pickup
{
    // Variables
    [SerializeField, Tooltip("How much healing?")] private float healing;

    // Class Variables
    public Health health;
    private PlayerRootMotion pRM;

    public override void Start()
    {
        health = GameManager.player.GetComponent<Health>();
        pRM = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerRootMotion>();
    }

    public override void OnPickUp ()
    {
        base.OnPickUp();
    }
    public override void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            pRM.ammoCount += 10;
            health.AddHealth(healing);
        }
        base.OnTriggerEnter(collision);
    }

}
