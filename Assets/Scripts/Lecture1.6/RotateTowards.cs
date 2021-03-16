using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowards : MonoBehaviour
{
    public Transform target;
    public float speed = 40f;

    private void Update()
    {
        Quaternion targetRotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, speed * Time.deltaTime);
    }

    /*This code is a modification of the LookRotation code above that rotates the object at 90 degrees/second towards the target instead of snapping to the desired rotation. GPE340*/
}
