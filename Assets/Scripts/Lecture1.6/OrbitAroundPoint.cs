using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitAroundPoint : MonoBehaviour
{
    public Transform orbitCenter;
    public float orbitSpeed = 45f;
    public Vector3 orbitAxis = Vector3.up;
    public Vector3 orbitOffset = Vector3.forward;
    private float currentAngle = 0f;

    private void Update()
    {
        currentAngle += orbitSpeed * Time.deltaTime;
        Quaternion orbitrotation = Quaternion.AngleAxis(currentAngle, orbitAxis);
        orbitOffset = orbitrotation * orbitOffset;
        transform.position = orbitCenter.position + orbitOffset;
    }
}
