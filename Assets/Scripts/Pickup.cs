using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickup : MonoBehaviour
{

    private Vector3 axis = Vector3.up;
    private float rotationSpeed = 90f;
    
    public virtual void OnTriggerEnter(Collider collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            OnPickUp();
        }
    }
    public virtual void Start()
    {

    }

    public virtual void OnPickUp()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        transform.rotation *= Quaternion.AngleAxis(rotationSpeed * Time.deltaTime, axis);
    }

}
