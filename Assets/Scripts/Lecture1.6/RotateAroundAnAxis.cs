using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundAnAxis : MonoBehaviour
{
    public Vector3 axis = Vector3.up;
    public float rotationSpeed = 90f;

    private void Update()
    {
        transform.rotation *= Quaternion.AngleAxis(rotationSpeed * Time.deltaTime, axis);
    }

    /* the code above generates a command telling the object to rotate a slight amount around a certain axis. Then the command is applied to the transform’s rotation with the *= operator. Since it does this every frame, the object rotates around the axis smoothly. GPE340*/
}
