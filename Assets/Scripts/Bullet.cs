
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //VARIABLES
    public float fireSpeed;
    public float delayTime;
    [SerializeField, Tooltip("Damage to Enemies")] private float damageTaken;

    // Class Variables
    private Health damage;
    
    private void Start()
    {
        damage = GetComponent<Health>();
    }
    // update - get bullets position and set new position, destroy object after delaytime
    private void Update()
    {
        // get objects position and add to forward, times speed and deltatime
        transform.position += transform.forward * (fireSpeed * Time.deltaTime);
        // destroy gameobject after delaytime(Seconds)
        Destroy(gameObject, delayTime);
    }
    // create on trigger with collider
    public void OnTriggerEnter(Collider other)
    {
        // set impacted collider(other) to gameobject otherObj   
        GameObject otherObj = other.gameObject;
        // get health component from object and set to otherHealth to check value
        Health otherHealth = otherObj.GetComponent<Health>();
        // if otherObj's health is not null/0 apply damage
        if (otherHealth != null)
        {   
            // call object health to be damaged by calling to damamgetohealth in Health script
            otherHealth.DamageToHealth(damageTaken);
        }
    }
}
