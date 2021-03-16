using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : Pickup
{
    // Variables
    [SerializeField, Tooltip("How much healing?")] private float healing;

    // Class Variables
    public Health health;

    public override void Start()
    {
        
    }

    public override void OnPickUp ()
    {
        base.OnPickUp();
    }
    public override void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            health.AddHealth(healing);
        }
        base.OnTriggerEnter(collision);
    }

}
