using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    // VARIABLES
    // Header for Inverse Kinematics
    // points for IK, set by designer
    [Header("IK Points")]
    public Transform rightHandPoint;
    public Transform leftHandPoint;
    // variables for instantiate bullet
    public GameObject bulletPF;
    public Transform bulletStart;

    [SerializeField, Tooltip("Time between shots")] private float timeTillNextShot = 1f;
    private float timeSinceLastShot = 0f;

    // Start is called before the first frame update
    public virtual void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void Update()
    {
        timeSinceLastShot += Time.deltaTime;
    }
    // instantiate bullet using prefab=PF, and set to position/rotation of bulletStart/FirePoint
    public void FireBullet()
    {
        if (timeSinceLastShot >= timeTillNextShot)
        {
            Instantiate(bulletPF, bulletStart.position, bulletStart.rotation);
            timeSinceLastShot = 0f;
        }
        
    }
}
